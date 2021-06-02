import glob, os
from dotmap import DotMap
def load_relation(filename):
 data=[]
 with open(filename,'r') as file:
  txt=file.read()
  lines=txt.split('\n')
  
  #extract attributes
  attributes=[]
  primary_keys_indices=[]
  
  open_bracket_seen=False
  close_bracket_seen=False
  current_attr_is_id=False
  word=""
  
  for i in range(len(lines[0])):
   if lines[0][i] == '(':
    open_bracket_seen=True
    continue
   elif lines[0][i] == ')':
    close_bracket_seen=True
    
   
   if open_bracket_seen==True:
    
    if lines[0][i]==':':     
     current_attr_is_id=True     
    elif lines[0][i]==',' or close_bracket_seen==True:
     attributes.append(word)
     word=""
     if current_attr_is_id==True:
      primary_keys_indices.append(len(attributes)-1)
      current_attr_is_id=False
    else:
     word+=lines[0][i]
  
  
  for i in range(1,len(lines)):
   line=lines[i]
   values=line.split(',')
   dict={}
   for j in range(len(attributes)):
    dict[attributes[j]]=values[j]
   d=DotMap(dict)
   data.append(d)
 
 return data
      
def load_DB(dirpath):
 os.chdir(dirpath)
 dict={}
 for file in glob.glob("*_relation.txt"):
     base=os.path.basename(file)
     base=os.path.splitext(base)[0]
     base=base.split('_relation')[0]
     relation=load_relation(file)    
     dict[base]=relation
    
 db=DotMap(dict)
 return db



def select(collection,condition_function):
 lst=[]
 for item in collection:
  if condition_function(item)==True:
   #yield item
   lst.append(item)
 return lst

def project(collection,attributes):
 lst=[]
 for item in collection:
  dict={}
  for attribute in attributes:
   dict[attribute]=item[attribute]
  d=DotMap(dict)
  lst.append(d)
 return lst

def cross_product(collection1,collection2,condition_function):
 lst=[]
 for item1 in collection1:  
  for item2 in collection2:   
   if condition_function(item1,item2)==True:
    dict={}
    for k in item1.items():
     dict[k[0]]=k[1]
    for k in item2.items():
     if k[0] in item1.keys():dict[k[0] + "_2"]=k[1]
     else:dict[k[0]]=k[1]
    d=DotMap(dict)
    lst.append(d)
 return lst

def union(collection1,collection2,equality_check_function):
 lst=[]
 ok=True
 for k in collection1[0].keys():
  if k not in collection2[0].keys():
   ok=False
   break
 if ok==True:
  for item1 in collection1:
    lst.append(item1)
    
  for item1 in collection2:
   exist=False
   for item2 in lst:
    if equality_check_function(item1,item2)==True:
     exist=True
     break
   if exist==False:lst.append(item1)
 return lst

def difference(collection1,collection2,equality_check_function):
 lst=[]
 ok=True
 for k in collection1[0].keys():
  if k not in collection2[0].keys():
   ok=False
   break
 if ok==True:
  for item1 in collection1:
   exist=False    
   for item2 in collection2:
     if equality_check_function(item1,item2)==True:
      exist=True
      break
   if exist==False:lst.append(item1)
 return lst



db=load_DB("C:\\Users\\Kashira Computer\\Desktop\\Me\\Pari naz\\1400\\data\\db\\")


q1=project(
           cross_product(
                   select(db.account,lambda acc: int(acc.balance)>=700)
                   ,db.depositor,lambda acc,dep: acc.account_number==dep.account_number),['customer_name','branch_name','balance'])

print('customer_name','branch_name','balance\n')
for item in q1:
 print(item.customer_name,item.branch_name,item.balance)

#q2=union(db.account,[DotMap({'account_number':'A-9001','branch_name':'B-443','balance':'34000'})],lambda x,y:x.account_number==y.account_number)
#for u in q2:
# print(u)

#q3=difference(db.account,[DotMap({'account_number':'A-215','branch_name':'Mianus','balance':'700'})],lambda x,y:x.account_number==y.account_number)
#for u in q3:
# print(u)



 