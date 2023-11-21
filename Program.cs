using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;

namespace WrapperForUsingAWorkingLibraryWithAlgebraOnEllipticCurves;

public static class Program
{
    public static void Main()
    {
        ECCWrapper eccWrapper = new ECCWrapper("secp256k1");

        // Отримання G-генератора
        ECPoint G = eccWrapper.BasePointGGet();
        Console.WriteLine("G: " + eccWrapper.ECPointToString(G));

        // Генерація випадкових чисел k та d
        BigInteger k = SetRandom(256);
        BigInteger d = SetRandom(256);

        // Створення точок H1 та H2
        ECPoint H1 = eccWrapper.ScalarMult(d, G);
        ECPoint H2 = eccWrapper.ScalarMult(k, H1);

        Console.WriteLine("H1: " + eccWrapper.ECPointToString(H1));
        Console.WriteLine("H2: " + eccWrapper.ECPointToString(H2));

        // Створення точок H3 та H4
        ECPoint H3 = eccWrapper.ScalarMult(k, G);
        ECPoint H4 = eccWrapper.ScalarMult(d, H3);

        Console.WriteLine("H3: " + eccWrapper.ECPointToString(H3));
        Console.WriteLine("H4: " + eccWrapper.ECPointToString(H4));

        // Перевірка рівності H2 та H4
        bool result = eccWrapper.AreEqual(H2, H4);
        Console.WriteLine("Are H2 and H4 equal? " + result);

        // Демонстрація роботи інших методів
        ECPoint sum = eccWrapper.AddECPoints(H2, H4);
        Console.WriteLine("Sum of H2 and H4: " + eccWrapper.ECPointToString(sum));

        ECPoint doubled = eccWrapper.DoubleECPoints(H1);
        Console.WriteLine("Double H1: " + eccWrapper.ECPointToString(doubled));

        // Виведення рядка точки на екран
        string serializedPoint = eccWrapper.ECPointToString(G);
        Console.WriteLine("Serialized G: " + serializedPoint);

        // Десеріалізація точки з рядка
        ECPoint deserializedPoint = eccWrapper.StringToECPoint(serializedPoint);
        Console.WriteLine("Deserialized Point: " + eccWrapper.ECPointToString(deserializedPoint));

        // Виведення точки на екран
        eccWrapper.PrintECPoint(G);
    }

    // Генерація випадкового числа заданої бітової довжини
    public static BigInteger SetRandom(int bitLength)
    {
        Random random = new Random();
        byte[] randomBytes = new byte[(bitLength + 7) / 8];
        random.NextBytes(randomBytes);
        randomBytes[randomBytes.Length - 1] |= (byte)(1 << ((bitLength - 1) % 8));
        return new BigInteger(1, randomBytes);
    }
}