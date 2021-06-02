import requests
from bs4 import BeautifulSoup
import user as u
from unicodedata import normalize
import re

def _removeNonAscii(s): return "".join(i for i in s if ord(i)<128)

def getTopicInformation(URL,startPage,endPage,DesPath):
 x=1
 END=2

 if endPage is not None:
  END=endPage+1
 while x<END:
 
  print(x,END,'...\n\n')
  if x >= END : break
  #URL = 'https://www.tripadvisor.com/ShowTopic-g294226-i7220-k13228338-Bali_Corona_Virus_update-Bali.html'    
  if x!=1:
   lst=URL.split('-')
   lst.insert(4,'o{}'.format((x-1)*10))
   base1=lst[0]
   lst.remove(lst[0])
   URL=base1 +'-' + '-'.join(lst)
  
  page = requests.get(URL) 
  soup = BeautifulSoup(page.content, 'html.parser')
  if x==1:
   pager=soup.find(id='pager_top2')
   lastPage=pager.find_all('a',class_='paging taLnk')

  if startPage is not None:
   x=startPage
   continue
  
  if lastPage is not None and len(lastPage)>1 and endPage is None:
    END=int(lastPage[len(lastPage)-1].text)+1
    #print(END)

  posts = soup.find_all('div', class_='post')#find_all#firstPostBox
    
  if posts is None or len(posts)<=1:break
  
  file = open(DesPath + "{}.txt".format(x),'w')  
  for i in range(len(posts)):
   post=posts[i]
   username=(post.find('div',class_='username'))
   if username is None: continue
   username=(username.find('a')['href'].split('/')[-1]).split('?')[0]
   location=u.userInfo(username)
   if location is None: location='None'
   
   postDate=post.find('div',class_='postDate')
   postBody=post.find('div',class_='postBody')
   if i==0:
    postNum='0'
    titleText=post.find('span',class_='topTitleText')
   else:
    postNum=post.find('span',class_='postNum').get_text()
    titleText=post.find('span',class_='titleText') 
   if (i==0 and x==1) or (i>0):    
    file.write(username + '@#$' + location +'@#$' + postDate.text+'@#$' + titleText.text + '@#$' + postNum + '@#$' + _removeNonAscii(postBody.text) +'<END>' + '\n')
    
      
  file.close()
  x+=1