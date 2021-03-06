﻿using JustGiving.Api.Sdk.ApiClients;
using JustGiving.Api.Sdk.Model.Charity;
using NUnit.Framework;

namespace JustGiving.Api.Sdk.Test.Integration.ApiClients
{
    [TestFixture]
    public class CharityApiTests
    {
        [TestCase(WireDataFormat.Json)]
        [TestCase(WireDataFormat.Xml)]
        public void RetrieveCharity_IssuedWithKnownId_ReturnsCharity(WireDataFormat format)
        {
            var client = TestContext.CreateClientNoCredentials(format);
			var charityClient = new CharityApi(client.HttpChannel);

            var item = charityClient.Retrieve(2050);

            Assert.IsNotNull(item);
            Assert.That(item.Name, Is.StringContaining("The Demo Charity"));
            Assert.That(item.SmsShortName, Is.StringMatching("Your Charity Campaign"));
        }

        [TestCase(WireDataFormat.Json)]
        [TestCase(WireDataFormat.Xml)]
        public void AuthenticateCharityUser_ValidUser_ReturnsIsValidAndCharityId(WireDataFormat format)
        {
            var client = TestContext.CreateClientValidCredentials(format);
			var charityClient = new CharityApi(client.HttpChannel);
            var authenticateCharityUserRequest = new AuthenticateCharityUserRequest()
            {
                Username = TestContext.CharityTestUserName,
                Password = TestContext.CharityTestUserPassword,
                Pin = TestContext.CharityTestUserPin
            };
            var response = charityClient.Authenticate(authenticateCharityUserRequest);
            Assert.That(response.IsValid, Is.True);
        }

        [TestCase(WireDataFormat.Json)]
        [TestCase(WireDataFormat.Xml)]
		[Ignore("Not yet live")]
        public void RetrieveEvents_ReturnsEventsDto(WireDataFormat format)
        {
            var client = TestContext.CreateClientValidCredentials(format);
			var charityClient = new CharityApi(client.HttpChannel);
            var response = charityClient.RetrieveEvents(2357);
            Assert.That(response, Is.Not.Null);
            Assert.That(response.CharityId, Is.Not.EqualTo(0));
        }
    }
}
