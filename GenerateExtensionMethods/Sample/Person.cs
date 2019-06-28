using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using VivaLing.Biz.Pattern;
using VivaLing.Models.BaseData;
using VivaLing.Pattern;
using VivaLing.Pattern.Attributes;
using VivaLing.Pattern.Interfaces;

namespace VivaLing.Models.Account
{
    public interface IPersonEntity : IEntity, IDisplayName, IAccount, IInfo, IDataCenter, ITrackVerify
    {
        int? AccountId { get; set; }
        string FirstName { get; set; }
        string MidName { get; set; }
        string LastName { get; set; }
        string NickName { get; set; }
        int? CityId { get; set; }
        int? LocationId { get; set; }
        Enums.Roles MajorRole { get; set; }
        DataCenter BornDataCenter { get; set; }
        LanguageInit.Ids SpokenLanguage { get; set; }
        LanguageInit.Ids CommunicationLanguage { get; set; }
        DateTime BirthDate { get; set; }
        Enums.Gender Gender { get; set; }
        Enums.UserStatus Status { get; set; }
    }

    [Table(nameof(Person))]
    public class Person : EntityWithExtension<Person, PersonExtension, PersonExtensionType>, IPersonEntity
    {
        public Person()
        {
            BirthDate = Pattern.Constants.Db.DefaultDateTime;
            this.TrackDefault();
            MajorRole = Enums.Roles.None;
        }
        
        [MaxLength(40)]        
        public new string Name { get; set; }

        [MigrationConsider]
        public int? AccountId { get; set; }

        [ForeignKey("AccountId")]
        [IgnoreDataMember]
        [VLIgnore]
        [JsonIgnore]
        public virtual Account Account { get; set; }

        [MaxLength(40)]
        public string FirstName { get; set; }
        [MaxLength(40)]
        public string MidName { get; set; }
        [MaxLength(40)]
        public string LastName { get; set; }
        [MaxLength(40)]
        public string DisplayName { get; set; }
        [MaxLength(50)]
        public string NickName { get; set; }
        
        [MaxLength(50)]
        public string Email { get; set; }

        /// <summary>
        /// Validate by Country
        /// </summary>
        [MaxLength(50)]
        public string Phone { get; set; }

        [MaxLength(500)]
        public string Info { get; set; }
        
        public int? CityId { get; set; }

        /// <summary>
        /// Require to city level in China (configurable), require to country level for global
        /// </summary>
        public int? LocationId { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get;set; }

        public Enums.Roles MajorRole { get; set; }
        
        public Enums.UserStatus Status { get; set; }

        public DataCenter BornDataCenter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public LanguageInit.Ids SpokenLanguage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public LanguageInit.Ids CommunicationLanguage { get; set; }

        public DateTime BirthDate { get; set; }

        public Enums.Gender Gender { get; set; }

        public DateTime InsertDate { get; set; }
        public int InsertId { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UpdateId { get; set; }
        public bool IsVerified { get; set; }
        public DateTime VerifyDate { get; set; }
        public int VerifyId { get; set; }
        public DataCenter DataCenter { get; set; }   
       
        [NotMapped]
        public virtual string ScreenName => this.GetStrExtension(PersonExtensionType.ScreenName);

        [NotMapped]
        public virtual string ZoomConferenceId => this.GetStrExtension(PersonExtensionType.ZoomConferenceId);        
    }
}
