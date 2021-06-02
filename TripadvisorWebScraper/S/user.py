import requests
from bs4 import BeautifulSoup

def userInfo(username):

 URL = 'https://www.tripadvisor.com/Profile/'+username 
 page = requests.get(URL) 
 soup = BeautifulSoup(page.content, 'html.parser')
 span=soup.find('span',class_='_2VknwlEe _3J15flPT default')
 if span is not None:
  return span.get_text()
 return None
 