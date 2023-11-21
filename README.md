# WrapperForUsingAWorkingLibraryWithAlgebraOnEllipticCurves
# ECCWrapper
# Під час виконання роботи використовувався ChatGPT!!!

Цей проект містить клас `ECCWrapper`, який є обгорткою для роботи з еліптичними кривими з використанням бібліотеки Bouncy Castle в мові програмування C#.

## Встановлення з NuGet пакетами

Для використання цього проекту, встановіть NuGet пакет Bouncy Castle. Відкрийте консоль дотнету та використовуйте наступну команду:
```
dotnet add package BouncyCastle.Cryptography
```

## Використання класу ECCWrapper
- Створіть екземпляр класу ECCWrapper та передайте назву кривої у конструктор.
```
ECCWrapper eccWrapper = new ECCWrapper("secp256r1");
```
Примітка: Замість "secp256r1" використовуйте назву конкретної еліптичної кривої, яку ви плануєте використовувати.

- Використовуйте методи класу ECCWrapper для виконання різних операцій з точками на еліптичній кривій. Наприклад:
```
ECPoint G = eccWrapper.BasePointGGet();
BigInteger k = SetRandom(256);
ECPoint H1 = eccWrapper.ScalarMult(k, G);
```
Всі методи класу дозволяють вам виконувати операції з точками, такі як додавання, подвоєння, множення на скаляр та інші.

- Запуск програми та перевірка результатів:
```
dotnet run
```
Програма виведе інформацію про використання методів класу та результати їхньої роботи.

## Деталі методів класу ECCWrapper
1. BasePointGGet()
- Метод отримує G-генератор для обраної еліптичної кривої.

2. ECPointGen(BigInteger x, BigInteger y)
- Метод створює точку на еліптичній криві з заданими координатами x та y.

3. IsOnCurveCheck(ECPoint point)
- Метод перевіряє, чи точка point належить до еліптичної кривої.

4. AddECPoints(ECPoint a, ECPoint b)
- Метод виконує додавання двох точок a та b на еліптичній кривій.

5. DoubleECPoints(ECPoint a)
- Метод виконує подвоєння точки a на еліптичній кривій.

6. ScalarMult(BigInteger k, ECPoint a)
- Метод виконує множення точки a на скаляр k на еліптичній кривій.

7. ECPointToString(ECPoint point)
- Метод серіалізує точку point в рядок.

8. StringToECPoint(string s)
- Метод десеріалізує рядок s в точку на еліптичній кривій.

9. PrintECPoint(ECPoint point)
- Метод виводить координати точки point на екран.
