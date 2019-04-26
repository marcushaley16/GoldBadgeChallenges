using _02_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Challenge_Console
{
    public class ProgramUI
    {
        private ClaimsRepository _claimsRepo = new ClaimsRepository();

        internal void Run()
        {
            SeedList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool running = true;
            while (running)
            {
                Console.Clear();

                Console.WriteLine("What would you like to do?\n" +
                    "1. See all claims\n" +
                    "2. Take care of the next claim\n" +
                    "3. Enter a new claim\n" +
                    "4. Exit\n");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        // See all claims
                        SeeAllClaimsInQueue();
                        break;
                    case "2":
                        // Take care of the next claim
                        NextClaimInQueue();
                        break;
                    case "3":
                        // Enter a new claim
                        AddNewClaimToQueue();
                        break;
                    case "4":
                        // Exit
                        running = false;
                        break;
                }
            }
        }

        private void SeeAllClaimsInQueue()
        {
            Console.Clear();

            Queue<Claims> queue = _claimsRepo.SeeAllClaims();

            if (queue.Count != 0)
            {
                foreach (Claims claim in queue)
                {
                    Console.WriteLine($"Claim ID: {claim.ClaimID}\n" +
                        $"Type: {claim.ClaimType}\n" +
                        $"Description: {claim.ClaimDescription}\n" +
                        $"Amount: {claim.ClaimAmount}\n" +
                        $"Date of Incident: {claim.DateOfIncident}\n" +
                        $"Date of Claim: {claim.DateOfClaim}\n" +
                        $"Valid: {claim.IsValid}\n");
                }
            }
            else
            {
                Console.WriteLine("The queue is empty. All claims have been processed.");
            }
            Console.ReadLine();
        }

        private void NextClaimInQueue()
        {
            Console.Clear();

            Claims peekClaim = _claimsRepo.PeekNextClaim();

            if (peekClaim != null)
            {
                Console.WriteLine($"Here are the details for the next claim to be handled:\n" +
                    $"Claim ID: {peekClaim.ClaimID}\n" +
                    $"Type: {peekClaim.ClaimType}\n" +
                    $"Description: {peekClaim.ClaimDescription}\n" +
                    $"Amount: {peekClaim.ClaimAmount}\n" +
                    $"Date of Incident: {peekClaim.DateOfIncident}\n" +
                    $"Date of Claim: {peekClaim.DateOfClaim}\n" +
                    $"Valid: {peekClaim.IsValid}\n");

                Console.WriteLine("Would you like to deal with this claim now? ( Y / N )");
                string yesOrNoString = Console.ReadLine().ToLower(); // Converts to all lowercase
                bool yesOrNo = false;

                switch (yesOrNoString)
                {
                    case "y":
                    case "yes":
                        yesOrNo = true;
                        Console.Clear();
                        Claims nextClaim = _claimsRepo.GetNextClaim();
                        Console.WriteLine($"Claim ID: {nextClaim.ClaimID}\n" +
                                $"Type: {nextClaim.ClaimType}" +
                                $"Description: {nextClaim.ClaimDescription}\n" +
                                $"Amount: {nextClaim.ClaimAmount}\n" +
                                $"Date of Incident: {nextClaim.DateOfIncident}\n" +
                                $"Date of Claim: {nextClaim.DateOfClaim}\n" +
                                $"Valid: {nextClaim.IsValid}\n");
                        break;
                    case "n":
                    case "no":
                    default: // Makes it default to false if y, yes, n, no is not entered
                        yesOrNo = false;
                        RunMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("The queue is empty. All claims have been processed.");
            }
            Console.ReadLine();
        }

        private void AddNewClaimToQueue()
        {
            Console.Clear();

            Console.WriteLine("Enter the claim ID: ");
            string idAsString = Console.ReadLine();
            int claimID = int.Parse(idAsString);

            Console.WriteLine("Enter the claim Type: \n" +
                "1. Car\n" +
                "2. Home\n" +
                "3. Theft\n");
            string typeAsString = Console.ReadLine();
            int input = int.Parse(typeAsString);
            ClaimType claimType = (ClaimType)input;

            Console.WriteLine("Enter a claim description: ");
            string claimDescription = Console.ReadLine();

            Console.WriteLine("Amount of Damage: ");
            string amountAsString = Console.ReadLine();
            decimal claimAmount = decimal.Parse(amountAsString);

            Console.WriteLine("Date of Accident: ");
            string dateOfIncidentString = Console.ReadLine();
            DateTime dateOfIncident = DateTime.Parse(dateOfIncidentString);

            Console.WriteLine("Date of Claim: ");
            string dateOfClaimString = Console.ReadLine();
            DateTime dateOfClaim = DateTime.Parse(dateOfClaimString);

            Console.WriteLine("IsValid: ( Y / N )");
            string isValidString = Console.ReadLine().ToLower();
            bool isValid = false;
            switch (isValidString)
            {
                case "y":
                case "yes":
                    isValid = true;
                    break;
                case "n":
                case "no":
                default:
                    isValid = false;
                    break;
            }
            Claims newClaim = new Claims(claimID, claimType, claimDescription, claimAmount, dateOfIncident, dateOfClaim, isValid);
            _claimsRepo.AddNewClaim(newClaim);
        }

        private void SeedList()
        {
            Claims claimOne = new Claims(2617, ClaimType.Car, "Customer backed into a taco truck.", 850.00m, new DateTime (2019, 4, 10), new DateTime (2019, 4, 15), true);
            Claims claimTwo = new Claims(1624, ClaimType.Home, "Struck by lightning.", 25000.00m, new DateTime(2019, 4, 5), new DateTime(2019, 4, 12), true);

            _claimsRepo.AddNewClaim(claimOne);
            _claimsRepo.AddNewClaim(claimTwo);
        }
    }
}
