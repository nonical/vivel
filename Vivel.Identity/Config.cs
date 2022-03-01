// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.


using System.Collections.Generic;
using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace Vivel.Identity
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("scope1", "API - full access")
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // swagger
                new Client
                {
                    ClientId = "vivel.swagger",
                    ClientSecrets = {new Secret("88d7eaf8-08a0-48a5-ae3b-02d46db9cc73".Sha256())},

                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,

                    RedirectUris = {"http://localhost:5001/swagger/oauth2-redirect.html"},
                    AllowedCorsOrigins = {"http://localhost:5001"},
                    AllowedScopes = { "scope1" }
                },

                new Client
                {
                    ClientId = "vivel.mobile",
                    ClientSecrets = { new Secret("2bc63e15-a44a-42e9-8597-2fcdee8350e0".Sha256()) },

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowOfflineAccess = true,

                    RedirectUris = { "com.nonical.vivel:/callback" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "scope1"
                    },
                },

                new Client
                {
                    ClientId = "vivel.web",
                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.Code,
                    AllowOfflineAccess = true,

                    RedirectUris = { "http://localhost:3000/redirect" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "scope1"
                    },
                },

                new Client
                {
                    ClientId = "vivel.desktop",
                    RequireClientSecret = false,

                    AllowedGrantTypes = GrantTypes.Code,

                    RedirectUris = { "http://localhost/winforms.client" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "scope1"
                    },
                }
            };
    }
}
