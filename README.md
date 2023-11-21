# WrapperForUsingAWorkingLibraryWithAlgebraOnEllipticCurves
# ECCWrapper
# Під час виконання роботи використовувався ChatGPT!!!

Цей проект містить клас `ECCWrapper`, який є обгорткою для роботи з еліптичними кривими з використанням бібліотеки Bouncy Castle в мові програмування C#.

## Встановлення з NuGet пакетами

Для використання цього проекту, встановіть NuGet пакет Bouncy Castle. Відкрийте консоль дотнету та використовуйте наступну команду:
```bash
dotnet add package BouncyCastle.NetCore
```

## Використання класу ECCWrapper
Створіть екземпляр класу ECCWrapper та передайте назву кривої у конструктор.
```
ECCWrapper eccWrapper = new ECCWrapper("secp256r1");
```
Примітка: Замість "secp256r1" використовуйте назву конкретної еліптичної кривої, яку ви плануєте використовувати.


