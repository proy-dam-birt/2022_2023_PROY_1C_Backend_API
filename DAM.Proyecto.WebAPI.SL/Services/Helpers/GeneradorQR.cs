using DAM.Proyecto.WebAPI.Domain.Entities.Ent;
using DAM.Proyecto.WebAPI.SL.Interfaces.IHelpers;
using QRCoder;

namespace DAM.Proyecto.WebAPI.SL.Services
{
    public class GeneradorQR : IGeneradorQR
    {
        public string generarQR(Reserva reserva)
        {
            string texto = $"{reserva.Lugar}{reserva.FechaReservada}{reserva.Plazas}{reserva.ReservaNum}{reserva.UserNombre}{reserva.UserApellido}";
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(texto, QRCodeGenerator.ECCLevel.Q);
            AsciiQRCode qrCode = new AsciiQRCode(qrCodeData);
            string qrCodeAsAsciiArt = qrCode.GetGraphic(2);
            return qrCodeAsAsciiArt;
        }
    }
}