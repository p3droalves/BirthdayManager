using System.ComponentModel.DataAnnotations;

namespace BirthdayManager.Models
{
	public class Friend
	{
		
		public int FriendId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

	}
}
