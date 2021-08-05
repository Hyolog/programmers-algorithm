#https://programmers.co.kr/learn/courses/30/lessons/12906?language=python3

def solution(arr):
    answer = []
    tempValue = -1
    
    for item in arr:
        if (tempValue != item):
            answer.append(item)

        tempValue = item

    return answer