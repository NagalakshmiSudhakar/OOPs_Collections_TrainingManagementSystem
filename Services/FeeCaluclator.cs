
using System;

namespace OOPs_Collections_TrainingManagementSystem.Services
{
    public class FeeCalculator
    {
        public (decimal BaseFee, decimal TotalDiscount, decimal FinalFee)
            CalculateFee(decimal baseFee)
        {
            ValidateFee(baseFee);

            decimal surcharge = 0m;

            decimal finalFee = baseFee + surcharge;

            return (baseFee, 0m, finalFee);
        }

        public (decimal BaseFee, decimal TotalDiscount, decimal FinalFee)
            CalculateFee(
                decimal baseFee,
                bool earlyBirdEligible,
                bool groupDiscountEligible,
                bool isOnline)
        {
            ValidateFee(baseFee);

            decimal earlyBirdDiscount = 0m;
            decimal groupDiscount = 0m;

            if (earlyBirdEligible)
            {
                earlyBirdDiscount = baseFee * 0.10m;
            }

            if (groupDiscountEligible)
            {
                groupDiscount = baseFee * 0.05m;
            }

            decimal totalDiscount =
                earlyBirdDiscount + groupDiscount;

            decimal surcharge = isOnline ? 200m : 800m;

            decimal finalFee =
                baseFee - totalDiscount + surcharge;

            return (baseFee, totalDiscount, finalFee);
        }

        private void ValidateFee(decimal baseFee)
        {
            if (baseFee < 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(baseFee),
                    "Fee cannot be negative.");
            }
        }
    }
}
