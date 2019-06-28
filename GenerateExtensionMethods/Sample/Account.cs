using System;
using System.ComponentModel.DataAnnotations;
using VivaLing.Biz.Pattern;
using VivaLing.Models.BaseData;
using VivaLing.Pattern;
using VivaLing.Pattern.Interfaces;

namespace VivaLing.Models.Account
{
    public class Account : EntityWithExtension<Account, AccountExtension, AccountExtensionType>, IBornDataCenter, ITrackVerify, IAccount
    {
        public Account()
        {
            this.TrackDefault();
        }

        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        [MaxLength(32)]
        public string Password { get; set; }

        public Enums.Roles MajorRole { get; set; }
        public DataCenter BornDataCenter { get; set; }

        public DateTime InsertDate { get; set; }
        public int InsertId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateId { get; set; }
        public bool IsVerified { get; set; }
        public DateTime VerifyDate { get; set; }
        public int VerifyId { get; set; }
    }

    public enum AccountExtensionType
    {
        Role,
    }

    public class AccountExtension : EntityExtension<Account, AccountExtensionType>
    {
    }

    public static class AccountEx
    {
        public static void Map(this Account o, Account source)
        {
            o.MapBaseValueFrom(source);
            o.Email = source.Email;
            o.Phone = source.Phone;
            o.Password = source.Password;
            o.MajorRole = source.MajorRole;
            o.BornDataCenter = source.BornDataCenter;

            o.MapTrack(source);
        }
    }
}
