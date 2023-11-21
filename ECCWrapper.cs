using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.EC;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Utilities.Encoders;

namespace WrapperForUsingAWorkingLibraryWithAlgebraOnEllipticCurves;

public class ECCWrapper
{
    private readonly X9ECParameters CurveParams;

    public ECCWrapper(string curveName)
    {
        CurveParams = CustomNamedCurves.GetByName(curveName) ?? throw new ArgumentException("Invalid curve name");
    }

    // Отримання G-генератора
    public ECPoint BasePointGGet()
    {
        return CurveParams.G.Normalize();
    }

    // Створення точки EC
    public ECPoint ECPointGen(BigInteger x, BigInteger y)
    {
        ECCurve curve = CurveParams.Curve;
        return curve.CreatePoint(x, y);
    }

    // Перевірка, чи належить точка кривій
    public bool IsOnCurveCheck(ECPoint point)
    {
        ECCurve curve = CurveParams.Curve;
        return point.IsValid() && point.Curve.Equals(curve);
    }

    // Додавання двох точок на кривій
    public ECPoint AddECPoints(ECPoint a, ECPoint b)
    {
        return a.Add(b).Normalize();
    }

    // Подвоєння точки на кривій
    public ECPoint DoubleECPoints(ECPoint a)
    {
        return a.Twice().Normalize();
    }

    // Множення точки на скаляр
    public ECPoint ScalarMult(BigInteger k, ECPoint a)
    {
        return a.Multiply(k).Normalize();
    }

    // Серіалізація точки в рядок
    public string ECPointToString(ECPoint point)
    {
        byte[] encodedPoint = point.GetEncoded();
        return Hex.ToHexString(encodedPoint);
    }

    // Десеріалізація точки з рядка
    public ECPoint StringToECPoint(string s)
    {
        ECCurve curve = CurveParams.Curve;
        byte[] encodedPoint = Hex.Decode(s);
        return curve.DecodePoint(encodedPoint).Normalize();
    }

    // Порівняння двох точок
    public bool AreEqual(ECPoint a, ECPoint b)
    {
        return a.Normalize().Equals(b.Normalize());
    }

    // Порівняння двох точок за їхніми строковими представленнями
    public bool AreEqual(string s1, string s2)
    {
        ECPoint point1 = StringToECPoint(s1);
        ECPoint point2 = StringToECPoint(s2);

        return AreEqual(point1, point2);
    }

    // Виведення точки на екран
    public void PrintECPoint(ECPoint point)
    {
        Console.WriteLine(point.Normalize());
    }
}