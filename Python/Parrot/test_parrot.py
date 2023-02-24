from parrot import Parrot, ParrotType
from unittest import TestCase

class ParrotTest(TestCase):
    def test_speedOfEuropeanParrot(self):
        parrot = Parrot(ParrotType.EUROPEAN, 0, 0, False)
        self.assertEqual(12.0, parrot.speed())


    def test_speedOfAfricanParrot_With_One_Coconut(self):
        parrot = Parrot(ParrotType.AFRICAN, 1, 0, False)
        self.assertEqual(3.0, parrot.speed())


    def test_speedOfAfricanParrot_With_Two_Coconuts(self):
        parrot = Parrot(ParrotType.AFRICAN, 2, 0, False)
        self.assertEqual(0.0, parrot.speed())


    def test_speedOfAfricanParrot_With_No_Coconuts(self):
        parrot = Parrot(ParrotType.AFRICAN, 0, 0, False)
        self.assertEqual(12.0, parrot.speed())


    def test_speedNorwegianBlueParrot_nailed(self):
        parrot = Parrot(ParrotType.NORWEGIAN_BLUE, 0, 1.5, True)
        self.assertEqual(0.0, parrot.speed())


    def test_speedNorwegianBlueParrot_not_nailed(self):
        parrot = Parrot(ParrotType.NORWEGIAN_BLUE, 0, 1.5, False)
        self.assertEqual(18.0, parrot.speed())


    def test_speedNorwegianBlueParrot_not_nailed_high_voltage(self):
        parrot = Parrot(ParrotType.NORWEGIAN_BLUE, 0, 4, False)
        self.assertEqual(24.0, parrot.speed())