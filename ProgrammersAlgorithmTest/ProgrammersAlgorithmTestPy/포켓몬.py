#https://programmers.co.kr/learn/courses/30/lessons/1845?language=python3

def solution(nums):
    halfNumsLength = len(nums) / 2
    newNums = set(nums)
    newNumsLength = len(newNums)
    
    if halfNumsLength > newNumsLength :
        answer = newNumsLength
    else :
        answer = halfNumsLength
    
    return answer