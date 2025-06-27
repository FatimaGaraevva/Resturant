using System.ComponentModel.DataAnnotations;

namespace Resturants.ViewModels.ReservationVM
{
    public class CreateReservationVM
    {
       
            [Required(ErrorMessage = "Ad boş ola bilməz")]
            public string Name { get; set; }

            [Required, EmailAddress(ErrorMessage = "Düzgün email daxil edin")]
            public string Email { get; set; }

            [Required, Phone(ErrorMessage = "Düzgün telefon nömrəsi daxil edin")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Adam sayı boş ola bilməz")]
            [Range(1, 50, ErrorMessage = "1-50 arası olmalıdır")]
            public int NumberOfPeople { get; set; }

            [Required(ErrorMessage = "Tarix boş ola bilməz")]
            public DateTime Date { get; set; }

            [Required(ErrorMessage = "Saat boş ola bilməz")]
            public TimeSpan Time { get; set; }
        }
    }

