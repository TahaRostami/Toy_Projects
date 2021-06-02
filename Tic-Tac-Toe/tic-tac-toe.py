import random
import time
random.seed(10)

#1 <- 1 won, -1 <- -1 won, 0.5 <- draw, 0<- continue
def status(b):
 
 cntZero=0
 
 sumDiam1=0
 sumDiam2=0
 for i in range(len(b)):
  sumDiam1+=b[i][i]
  sumDiam2+=b[i][len(b)-i-1]
 
 if sumDiam1==len(b) or sumDiam2==len(b): return 1
 elif sumDiam1==len(b)*-1 or sumDiam2==len(b)*-1: return -1
 
 for i in range(len(b)):
  sumRow=0
  sumCol=0
  for j in range(len(b[i])):
   if b[i][j]==0: cntZero+=1
   sumRow+=b[i][j]
   sumCol+=b[j][i]
  if sumRow==len(b[i]) or sumCol==len(b[i]): return 1
  elif sumRow==len(b[i])*-1 or sumCol==len(b[i])*-1:return -1
 
 if cntZero == 0: return 0.5
 else: return 0
  
def printB(b):
 for i in range(len(b)):
  for j in range(len(b[i])):  
   if b[i][j]==1: print('x',end = " ")
   elif b[i][j]==-1: print('o',end = " ")
   else:print('-',end = " ")
  print('\n')   
  

def lst_empty_homes(b):
 lst=[]
 for i in range(len(b)):
  for j in range(len(b[i])):
   if empty(b,i,j):
    lst.append((i,j))
 return lst

def move(b,i,j,val):
 if b[i][j]==0:b[i][j]=val   
def empty(b,i,j):
 if b[i][j]==0:return True
 else: return False



def game():
 board = [[0,0,0],[0,0,0],[0,0,0]]
 turn=1#1,-1
 stat=0#0,-1,1,0.5
 
 humanPlayer=input("You want to be a X, or O: ")
 if humanPlayer == "O": humanPlayer=-1
 else: humanPlayer=1
 
 
 while(status(board)==0):  
  if humanPlayer == turn:   
   #human play
   i=int(input("i:"))
   j=int(input("j:"))
   if empty(board,i,j):
    move(board,i,j,humanPlayer)
    printB(board)
   else: continue
  else:
   pass
   #computer play 
   empty_homes=lst_empty_homes(board)
   slected_home=empty_homes[random.randint(0,len(empty_homes))]
   i=slected_home[0]
   j=slected_home[1]
   move(board,i,j,humanPlayer*-1)
   time.sleep(1)
   printB(board)
    
  if turn==0: turn=1
  else:turn=0

  
  
 print(status(board))
 
 
 

game()