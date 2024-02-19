using System;
using System.IO;
using dotenv.net;
using NUnit.Framework;

[SetUpFixture]
public class AssemblySetup
{
    [OneTimeSetUp]
    public void Setup()
    {
        DotEnv.Load();
    }
}