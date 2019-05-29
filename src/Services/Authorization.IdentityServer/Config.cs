using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace Krola.Authorization.IdentityServer
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
            };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new List<ApiResource>
            {
                new ApiResource("time_tracking_api", "Time Tracking API")
                {
                    ApiSecrets = { new Secret("time_tracking".Sha256()) },
                    Scopes = new List<Scope>
                    {
                        new Scope { Name = "time_tracking_client", DisplayName = "Time Tracking Client"},
                        new Scope { Name = "time_tracking_mobile", DisplayName = "Time Tracking Mobile"},
                    }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                // native clients
                new Client
                {
                    ClientId = "time.tracking",
                    ClientName = "TimeTracking",
                    
                    RequireClientSecret = true,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("time_tracking")
                    },

                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowedScopes = { "time_tracking_client", "time_tracking_mobile" },

                    AllowOfflineAccess = true,
                    RefreshTokenUsage = TokenUsage.ReUse
                }
            };
        }

        public static IEnumerable<TestUser> GetUsers()
        {
            return new List<TestUser> { new TestUser
            {
                Username = "TimeTrackingAdmin",
                Password = "admin",
                SubjectId = "1",
                IsActive = true
            }};
        }
    }

}
