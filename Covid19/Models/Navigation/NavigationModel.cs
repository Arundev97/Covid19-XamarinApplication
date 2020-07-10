using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace Covid19.Models.Navigation
{
    /// <summary>
    /// Model for the Navigation List and Tile with Cards page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class NavigationModel
    {
        #region Field

        // private string itemImage;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of an item.
        /// </summary>
        [DataMember(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of an item.
        /// </summary>
        [DataMember(Name = "Gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the image of an item.
        /// </summary>
        [DataMember(Name = "itemImage")]
        public string ItemImage
        {
            get
            {
                return App.BaseImageUrl; 
            }

            set
            {
               
            }
        }

        /// <summary>
        /// Gets or sets the average rating of an item.
        /// </summary>
        [DataMember(Name = "Age")]
        public string Age { get; set; }

        [DataMember(Name = "SlotID")]
        public string SlotID { get; set; }
        #endregion
    }
}