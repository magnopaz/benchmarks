import math
from time import perf_counter 

def is_prime(num):
        if num == 2:
            return True
        if num <= 1 or not num % 2:
            return False
        for div in range(3,int(math.sqrt(num)+1),2):
            if not num % div:
                return False
        return True

def benchtest():
    start = perf_counter()
    for i in range(10000000):
        is_prime(i)
    end = perf_counter()
    print (start)
    print (end)

benchtest()