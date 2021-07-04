import unittest

# 테스트 방식 수정 필요
from 포켓몬 import solution
from 나라의숫자124 import solution2

class Test_test_1(unittest.TestCase):
    def test_A(self):
         self.assertTrue(2 == solution([3,1,2,3]))
         self.assertTrue("1" == solution2(1))
         self.assertTrue("2" == solution2(2))
         self.assertTrue("4" == solution2(3))
         self.assertTrue("11" == solution2(4))

if __name__ == '__main__':
    unittest.main()
