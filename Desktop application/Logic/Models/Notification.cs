using MediaBazaar.Logic.Enums;
using System.ComponentModel.DataAnnotations;

namespace MediaBazaar.Logic.Models
{
    public class Notification
    {

        ///<summary> How Notification constructor works <paramref name="description"/>
        ///<para>When creating instance of Notification make sure that title is no more than 20 digits and description is no more than 100 digits </para>
        ///</summary>
        public Notification(int? forUserId, string title, string description, Platform platform)
        {
            ForUserId = forUserId;
            Title = title;
            Description = description;
            HasBeenSeen = false;
            Platform = platform;
        }

        ///<summary> How Notification constructor works <paramref name="description"/>
        ///<para>When creating instance of Notification make sure that title is no more than 20 digits and description is no more than 100 digits </para>
        ///</summary>
        public Notification(string title, string description, Platform platform,string? toJobDescription)
        {
            ToJobDescription = toJobDescription;
            Title = title;
            Description = description;
            HasBeenSeen = false;
            Platform = platform;
        }

        ///<summary> How Notification constructor works <paramref name="description"/>
        ///<para>When creating instance of Notification make sure that title is no more than 20 digits and description is no more than 100 digits </para>
        ///</summary>
        public Notification(string? toDaprtment, string title, string description, Platform platform)
        {
            ToDepartment = toDaprtment;
            Title = title;
            Description = description;
            HasBeenSeen = false;
            Platform = platform;
        }

        ///<summary> How Notification constructor works <paramref name="description"/>
        ///<para>When creating instance of Notification make sure that title is no more than 20 digits and description is no more than 100 digits </para>
        ///<para>This constructor is for getting the notification from data source </para>
        ///</summary>
        public Notification(int id, int? forUserId, string title, string description, bool hasBeenSeen)
        {
            Id = id;
            ForUserId = forUserId;
            Title = title;
            Description = description;
            HasBeenSeen = hasBeenSeen;
        }

        ///<summary> How Notification constructor works <paramref name="description"/>
        ///<para>When creating instance of Notification make sure that title is no more than 20 digits and description is no more than 100 digits </para>
        ///<para>This constructor is for Creating the notification from data source </para>
        ///</summary>
        public Notification(int id, int? forUserId, string title, string description, bool hasBeenSeen,Platform platform)
        {
            Id = id;
            ForUserId = forUserId;
            Title = title;
            Description = description;
            HasBeenSeen = hasBeenSeen;
            Platform = platform;
        }

        ///<summary> How Notification constructor works <paramref name="description"/>
        ///<para>When creating instance of Notification make sure that title is no more than 20 digits and description is no more than 100 digits </para>
        ///<para>This constructor is for Creating the notification from data source </para>
        ///</summary>
        public Notification(string? toJobDescription, int id, string title, string description, Platform platform)
        {
            Id = id;
            ToJobDescription = toJobDescription;
            Title = title;
            Description = description;
            HasBeenSeen = false;
            Platform = platform;
        }

        ///<summary> How Notification constructor works <paramref name="description"/>
        ///<para>When creating instance of Notification make sure that title is no more than 20 digits and description is no more than 100 digits </para>
        ///<para>This constructor is for Creating the notification from data source </para>
        ///</summary>
        public Notification(int id, string? toDaprtment, string title, string description, Platform platform)
        {
            Id = id;
            ToDepartment= toDaprtment;
            Title = title;
            Description = description;
            HasBeenSeen = false;
            Platform = platform;
        }



        public int Id { get; private set; }

        public int? ForUserId { get; private set; }

        public string? ToDepartment { get; private set; }

        public string? ToJobDescription { get; private set; }

        //This for to get the value of ToDepartment or ToJobDescription
        public string? ForType
        {
            get
            {

                if (ToDepartment == null && ToJobDescription == null)
                {
                    return null;
                }
                else if (ToDepartment == null)
                {
                    return ToJobDescription;
                }
                else if (ToJobDescription == null)
                {
                    return ToDepartment;
                }
                else
                {
                    return null;
                }
            }
        }

        [MaxLength(20)]
        public string Title { get; private set; }

        [MaxLength(100)]
        public string Description { get; private set; }

        public bool HasBeenSeen { get; private set; }

        public Platform Platform { get; private set; }

    }
}
