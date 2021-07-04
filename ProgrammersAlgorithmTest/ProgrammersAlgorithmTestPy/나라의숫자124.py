#https://programmers.co.kr/learn/courses/30/lessons/12899?language=python3

def solution2(n):
    if n <= 3:
        return '124'[n-1]
    else:
        q, r = divmod(n-1, 3)
        return solution2(q) + '124'[r]