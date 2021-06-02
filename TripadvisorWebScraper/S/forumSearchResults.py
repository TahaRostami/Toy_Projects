import requests
from bs4 import BeautifulSoup

#GetTopicsSearchURLs(URL,None,None,DesPath)#from 1 to end
#GetTopicsSearchURLs(URL,x,None,DesPath)#from x to end
#GetTopicsSearchURLs(URL,None,t,DesPath)#from 1 to table
#GetTopicsSearchURLs(URL,a,b,DesPath)#from a to b

#seperator @#$
#post title, href
def GetTopicsSearchURLs(URL,fromPage,toPage,DesPath):
 q=1
 tmp=False
 END=2
 while True:

  print(q,END,'...\n\n')
  if q>=END:break
  
  #URL = 'https://www.tripadvisor.com/SearchForums?q=Covid-19'
  if q>1:
   URL=URL+'&s=%20&o={}'.format((q-1)*10)
  
  page = requests.get(URL) 
  soup = BeautifulSoup(page.content, 'html.parser')

  if q==1:
   pagination=soup.find('div',class_='pagination')
   if pagination is not None:
    pagination=pagination.find_all('a') 
    if pagination is not None and len(pagination)>1:
     if pagination[len(pagination)-1].get_text() != "Next" and pagination[len(pagination)-1].get_text().isnumeric():
      END=int(pagination[len(pagination)-1].get_text())+1
      if toPage is not None:
       END=toPage+1
      #print(END)
     else:
      END=int(pagination[len(pagination)-2].get_text())+1
      if toPage is not None:
       END=toPage+1
      #print(END)
    
  if fromPage is not None and tmp==False:
   q=fromPage
   tmp=True
   continue
  
  #print(pagination,'\n')
  searchRes=soup.find('table',class_='forumsearchresults')
  searchRes=searchRes.find_all('tr' ,class_='topofgroup')
  file = open(DesPath + "{}.txt".format(q), "w")
  for i in range(len(searchRes)):
    sr=searchRes[i]
    td=(sr.find_all('td',class_='searchresultgrid'))[0]
    a=td.find('a')
    
    file.write(a.find('b').get_text() +'@#$' + 'https://www.tripadvisor.com'+a['href'] + '\n')
    #print('https://www.tripadvisor.com'+a['href'],'\n'*2)
    
  file.close()
   
  #print(".........................................................................................", end='\n'*2)   
  q+=1
