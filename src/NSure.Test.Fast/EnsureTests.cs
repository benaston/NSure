namespace NSure.Test.Fast
{
    using NUnit.Framework;

    [TestFixture]
    public class EnsureTests
    {
        [Test]
        public void EnsureThat_SuppliedWithTrue_DoesNotThrowAnException()
        {
            Assert.DoesNotThrow(() => Ensure.That(true, "m"));
        }
    }
}