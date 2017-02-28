using message360.Controllers;
using message360.Http.Client;

namespace message360
{
    public interface IMessage360Client
    {
        AccountController Account { get; }
        AddressController Address { get; }
        CallController Call { get; }
        CarrierController Carrier { get; }
        ConferenceController Conference { get; }
        EmailController Email { get; }
        NumberVerificationController NumberVerification { get; }
        PhoneNumberController PhoneNumber { get; }
        RecordingController Recording { get; }
        IHttpClient SharedHttpClient { get; set; }
        SMSController SMS { get; }
        SubAccountController SubAccount { get; }
        TranscriptionController Transcription { get; }
        UsageController Usage { get; }
        WebRTCController WebRTC { get; }
    }
}