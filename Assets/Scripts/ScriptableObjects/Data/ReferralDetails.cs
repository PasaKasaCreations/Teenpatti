using UnityEngine;

namespace ScriptableObjects.Data
{
    [CreateAssetMenu(fileName = "Referral Details", menuName = "Data/Referral Details")]
    public class ReferralDetails : ScriptableObject
    {
        public string referralId;

        public void SetReferralId(string referralId) => this.referralId = referralId;   
    }
}
