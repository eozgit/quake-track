using System;
using System.Collections.Generic;

namespace QuakeTrack.Models
{
    public static class SeedData
    {
        public static Project CreateProjectCatRamp()
        {
            return new Project
            {
                Name = "Make a Cat Ramp",
                Description = "We have this fancy cat litter box that is supposed to keep the dogs away from the box. EEEWWWWWW gross I know... Original: https://www.instructables.com/id/Why-Do-We-Want-to-Make-a-Cat-Ramp-You-Might-Ask/",
                Issues = new List<Issue> {
                            new Issue
                            {
                                Summary = "Get supplies: Hardware",
                                Description = "1. 1.5in/1.5in wood plank 100in\r\n2. 5in X 3/4in plank 8 feet long. Use recycled wood when possible.\r\n3. 6 2in screws.\r\n4. 2in nails x 20\r\n5. Dark stain small container.\r\n6. Inexpensive car carpet x1",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Done,
                                Priority = Priority.Medium,
                                Index = 0
                            },
                            new Issue
                            {
                                Summary = "Get supplies: Tools",
                                Description = "1. Hammer\r\n2. Foam brushes x2\r\n3. Tape measure\r\n4. Hand saw.\r\n5. Table saw\r\n6. Drill\r\n7. Staple Gun\r\n8. Metal file or sand paper\r\n9. Utility knife\r\n10. Work gloves and safety glasses",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Done,
                                Priority = Priority.Medium,
                                Index = 1
                            },
                            new Issue
                            {
                                Summary = "Marks for the First Cuts",
                                Description = "Mark the 1.5in X 1.5in wood as such:\r\n20in x 4\r\n6in x2\r\n2in x 2",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium,
                                Index = 0
                            },
                            new Issue
                            {
                                Summary = "Saw the Planks and Sand the Edges",
                                Description = "Use the metal file to take off the rough edges so you don't get a splinter",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium,
                                Index = 1
                            },
                            new Issue
                            {
                                Summary = "Fix the Frame to the Platform",
                                Description = "Place the 8in platform an on the workbench.\r\nTake the 2in and 6in pieces of 1.5 wood and make sure that they fit along with the legs.\r\nHammer in nails to fix the frame pieces to the platform.\r\nTake a drill bit that is a little smaller than the screws and drill pilot holes (so the wood doesn't split)",
                                IssueType = IssueType.Task,
                                Storypoints = 3,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium,
                                Index = 2
                            },
                            new Issue
                            {
                                Summary = "Stabilize the Platform",
                                Description = "Drill in the pilot holes and add the screws to each leg.\r\nThis makes the platform stable.",
                                IssueType = IssueType.Task,
                                Storypoints = 5,
                                Status = IssueStatus.Develop,
                                Priority = Priority.Medium,
                                Index = 0
                            },
                            new Issue
                            {
                                Summary = "Add the Ramp to the Platform",
                                Description = "Lay the plank on the lip and use a cinder block (or something heavy) to keep it in place.\r\nDrill the pilot holes at an angle into the frame and then use the 2 inch screws x4",
                                IssueType = IssueType.Task,
                                Storypoints = 3,
                                Status = IssueStatus.Develop,
                                Priority = Priority.Medium,
                                Index = 1
                            },
                            new Issue
                            {
                                Summary = "Cut the Carpet So That It Fits on the The Platform and Ramp",
                                Description = "Measure out 5.5in pieces. Using your utility knife, cut the carpet in pieces to completely cover the top of the ramp and platform",
                                IssueType = IssueType.Task,
                                Storypoints = 3,
                                Status = IssueStatus.Develop,
                                Priority = Priority.Medium,
                                Index = 2
                            },
                            new Issue
                            {
                                Summary = "Staple the Carpet to the Ramp",
                                Description = "Carefully align the cut carpet to the ramp.\r\nUsing your staple gun, staple in several places so that the carpet doesn't come up.",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium,
                                Index = 0
                            },
                            new Issue
                            {
                                Summary = "Apply the Stain Onto the Ramp",
                                Description = "Lay down a tarp.\r\nOpen the stain and be careful not to spill!\r\nUse the foam brushes and use even strokes on the wood until entirely coated.\r\nApply more coats if needed and let sit over night.",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium,
                                Index = 1
                            }
                    }
            };
        }

        public static Project CreateProjectFaceMask()
        {
            return new Project
            {
                Name = "Face Mask",
                Description = "A.B. Mask This pattern is designed to fit in two ways. First, directly over the face, similar to a surgical mask. Second, the pleats expand, allowing the mask to fit over many models of N-95... Original: https://www.instructables.com/id/AB-Mask-for-a-Nurse-by-a-Nurse/",
                Issues = new List<Issue> {
                            new Issue
                            {
                                Summary = "Get supplies",
                                Description = "Fat quarter of 100% cotton or other tightly woven material - the tighter the better\r\nsewing machine\r\niron",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Done,
                                Priority = Priority.Medium,
                                Index = 0
                            },
                            new Issue
                            {
                                Summary = "Print the Pattern",
                                Description = "https://drive.google.com/file/d/15IdBNXP8YYPPIz9EMEf35XM0HEJWUYxH/view\r\nCut out pattern. Cut along straight black lines and dotted black line.\r\nChoose your fabric - at least 21in x 18in (Fat Quarter). Iron out wrinkles.",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Done,
                                Priority = Priority.Medium,
                                Index = 1
                            },
                            new Issue
                            {
                                Summary = "Fold Fabric",
                                Description = "Fold fabric right-side out with selvage edge touching - taco style. Square fabric.",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium,
                                Index = 0
                            },
                            new Issue
                            {
                                Summary = "Cut Binding and Ties",
                                Description = "Cut 5 x 1.5 inch wide strips from the width of fabric. Each strip should be around 20\" in length.The strips above were cut with the fabric folded in half.\r\nOr, if you are cutting out of longer fabric you could cut 2 (1.5\" wide x 40\" long) and 1 (1.5\" wide x 20\" long) and save yourself a step piecing",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium,
                                Index = 1
                            },
                            new Issue
                            {
                                Summary = "Refold Fabric and Cut Mask Face",
                                Description = "Open up and refold leftover fabric. Fold width-wise - burrito style. So selvage on top, selvage on bottom - fold evenly. Pin pattern on upper half of folded fabric. Dotted line of pattern aligned with fold. Cut around edges of pattern. Cut out notches.\r\nUnpin pattern and move to lower half of folded",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium,
                                Index = 2
                            },
                            new Issue
                            {
                                Summary = "Stack and Sew",
                                Description = "Stack the 2 face mask pieces, face down. Pin in place.\r\nSew together using 1/2\" seam around all four sides.",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Develop,
                                Priority = Priority.Medium,
                                Index = 0
                            },
                            new Issue
                            {
                                Summary = "Iron in Pleats",
                                Description = "With pointed pointing away from you, front of fabric side down, bring bottom side of fabric up and over top side. The fold should be the imaginary line between the top notch on left to top notch on right. Press crease with hot iron. The pleats are 1/4 inch.\r\nNext, fold fabric back down.",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Develop,
                                Priority = Priority.Medium,
                                Index = 1
                            },
                            new Issue
                            {
                                Summary = "Sew Pleats in Place",
                                Description = "Sew pleats into place using a 1/2\" seam. Both Left and Right side of mask face.",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Develop,
                                Priority = Priority.Medium,
                                Index = 2
                            },
                            new Issue
                            {
                                Summary = "Mark and Sew Darts",
                                Description = "Fold mask face in half at the center fold. Front side of fabric together, wrong side of fabric facing you.\r\nAlign pattern and mark top and bottom darts with pin or pencil.\r\nSew along line. - I went over it twice for good measure.",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Develop,
                                Priority = Priority.Medium,
                                Index = 3
                            },
                            new Issue
                            {
                                Summary = "Trim Excess",
                                Description = "Trim seams to 1/4 inch.",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium,
                                Index = 0
                            },
                            new Issue
                            {
                                Summary = "Prepare the Binding",
                                Description = "Take 2 strips and pin at 90 deg angles. Repeat with 2 more strips.\r\nSew strips together at 45 deg angle. Trim seams at 1/4 inch and press with iron.\r\nTake 5th strip and cut in half.",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium,
                                Index = 1
                            },
                            new Issue
                            {
                                Summary = "Attach Side Binding",
                                Description = "With mask facing down - front side of fabric facing away, wrong side of fabric facing towards you - pin 1.5\" binding you cut in half to left and right side of mask. Binding should be face down. Edge of binding aligned with outermost edge of mask.\r\nSew in place, starting just above top of mask...",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium,
                                Index = 2
                            },
                            new Issue
                            {
                                Summary = "Finish Side Binding",
                                Description = "Flip mask over. Right side of fabric facing you.\r\nFold 1/4 inch seam towards you from outside edge of binding. Wrap folded edge around side edge of mask.\r\nPin in place.\r\nSew along edge of binding.\r\nRepeat on other side.\r\nTrim excess.",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium,
                                Index = 3
                            },
                            new Issue
                            {
                                Summary = "Attach Top/Bottom Binding",
                                Description = "With mask face, wrong side of fabric facing you, pin 1.5 inch binding strips along top and bottom edges.\r\nSew in place using 1/4 inch seams. Start sewing just above one side of mask face and end just after opposite side of mask face.\r\nPress open with iron.",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium,
                                Index = 4
                            },
                            new Issue
                            {
                                Summary = "Finish Top/Bottom Binding and Ties",
                                Description = "Trim ties even on both sides of mask.\r\nIron in 1/4 inch seam on top and bottom of mask ties.\r\nIron in 1/4 inch seam on end of mask ties.\r\nFold ties in half and pin in place.\r\nSew Binding and Ties.",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium,
                                Index = 5
                            }
                    }
            };
        }

        public static Project CreateProjectPerfectSteak()
        {
            return new Project
            {
                Name = "Pan Fry the Perfect Steak",
                Description = "One of my favorite meals to cook for myself is a pan fried steak. Steak is a tricky food to get right, but I have perfected my method for cooking one... Original: https://www.instructables.com/id/How-To-Pan-Fry-the-Perfect-Steak/",
                Issues = new List<Issue> {
                            new Issue
                            {
                                Summary = "Get Tools and Ingredients",
                                Description = "Here is a list of supplies you will need to cook your steak.\r\n\r\nTools\r\n\r\nA Stove\r\nOne frying pan suitable for the size of your steak\r\nTongs\r\na knife\r\na plate\r\nA clock or timer\r\n\r\nIngredients\r\n\r\nOne steak\r\nOlive oil\r\nButter\r\nSalt\r\nPepper\r\nFresh Garlic (or Garlic Powder)",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Done,
                                Priority = Priority.Medium,
                                Index = 0
                            },
                            new Issue
                            {
                                Summary = "Shop for a Steak",
                                Description = "The first step is to locate the steak that you wish to cook. I always buy my steak at Tacoma Boys. They have a quality meat selection. It is a bit more expensive, but in my opinion, it is worth it.\r\nThe steak I chose was a 8oz Kobe Petite Sirloin steak.",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Done,
                                Priority = Priority.Medium,
                                Index = 1
                            },
                            new Issue
                            {
                                Summary = "Prepare the Meat",
                                Description = "When you get home you must get the meat out and let it warm up. When it is sitting in the grocery store, it is very cold and you do not want to cook a cold steak.\r\nFirst pull the steak out of the butcher paper and let it rest on a plate. While it is sitting, use the salt and pepper to season it.",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium,
                                Index = 0
                            },
                            new Issue
                            {
                                Summary = "Seer the Steak",
                                Description = "This next step is very crucial and can be dangerous. At this point, the pan should be very hot. You will use the tongs to place the steak into the hot oil. At these high temperatures there will be a lot of oil splatter so be careful when maneuvering the steak around in the pan.",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium,
                                Index = 1
                            },
                            new Issue
                            {
                                Summary = "Cook the Steak",
                                Description = "At this point, the steak has been seared on all sides, locking in the juices of the meat. Turn down the heat of your stove to medium.\r\nNow comes the process of cooking through the meat to your preferred wellness. There is no exact science to this because of the variables of thickness and stove heat",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium,
                                Index = 2
                            },
                            new Issue
                            {
                                Summary = "Rest the Meat",
                                Description = "You have finished cooking the steak and are about to devour it but RESIST!\r\nYou must let the meat rest before cutting into it. The process known as resting, allows for all of the juices of the meat to lock inside the steak. This gives your steak better flavor.\r\nAllow the steak to rest for 5 minutes.",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Develop,
                                Priority = Priority.Medium,
                                Index = 0
                            },
                            new Issue
                            {
                                Summary = "Eat and Enjoy",
                                Description = "You have been patient. You have waited five minutes. You are now ready to consume your amazing, and surprisingly inexpensive steak!\r\nThis steak requires no sauces. Sauce would only ruin the great flavors that you have created today in your pan.\r\nSteamed vegetables and a cold beer also work as great ",
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium,
                                Index = 0
                            }
                    }
            };
        }
    }
}