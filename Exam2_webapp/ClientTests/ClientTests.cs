using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace Exam2_webapp.ClientTests
{
    [TestFixture]
    public class ClientTests
    {
        private readonly double compareAccuracy = 1e-5;

        [Test]
        public void SimpleTest()
        {
            Assert.That(2, Is.EqualTo(1 + 1));
        }

        [TestCase(1000, 0.2)]
        public async Task ResistorCreateTest(double resistance, double accuracy)
        {
            var createInfo = new View.Resistors.ResistorCreateInfo() {
                Resistance = resistance,
                Accuracy = accuracy
            };
            var client = new Client.ElementsClient("https://localhost:5001");

            var resistor = await client.CreateResistorAsync(createInfo);
          
            Assert.That(resistor.Resistance, Is.InRange(resistance - compareAccuracy, resistance + compareAccuracy));
            Assert.That(resistor.Accuracy, Is.InRange(accuracy - compareAccuracy, accuracy + compareAccuracy));
        }


    }
}