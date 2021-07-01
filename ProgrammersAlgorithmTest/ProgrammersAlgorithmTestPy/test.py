import unittest

from 포켓몬 import solution

class Test_test_1(unittest.TestCase):
    def test_A(self):
         self.assertTrue(2 == solution([3,1,2,3]))

if __name__ == '__main__':
    unittest.main()
