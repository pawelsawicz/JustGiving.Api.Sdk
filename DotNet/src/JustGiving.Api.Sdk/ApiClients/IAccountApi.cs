﻿using JustGiving.Api.Sdk.Model.Account;
using JustGiving.Api.Sdk.Model.Page;

namespace JustGiving.Api.Sdk.ApiClients
{
    public interface IAccountApi: IAccountApiAsync
    {
        bool AreCredentialsValid(string email, string password);
        string Create(CreateAccountRequest request);
        FundraisingPageSummaries ListAllPages(string email);
        void RequestPasswordReminder(string email);
        bool IsEmailRegistered(string email);
        AccountDetails RetrieveAccount();
    }
}