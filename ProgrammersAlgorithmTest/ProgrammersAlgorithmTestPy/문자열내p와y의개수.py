import unittest

def solution(s):
    if ((s.count("p") + s.count("P")) == (s.count("y") + s.count("Y"))):
        return True
    
    return False

    
class TestStringMethods(unittest.TestCase):

    def test(self):
        self.assertEqual(solution("PpoooyY"), True)
        self.assertEqual(solution("PoooyY"), False)


if __name__ == '__main__':
    unittest.main()