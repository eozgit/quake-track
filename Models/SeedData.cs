using System;
using System.Linq;
using System.Collections.Generic;
using IdentityServer4.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using QuakeTrack.Data;

namespace QuakeTrack.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>(),
                serviceProvider.GetRequiredService<IOptions<OperationalStoreOptions>>()))
            {
                if (context.Project.Any())
                {
                    return;
                }

                context.Project.AddRange(
                    new Project
                    {
                        Name = "Make a Cat Ramp",
                        Description = "We have this fancy cat litter box that is supposed to keep the dogs away from the box. EEEWWWWWW gross I know... Original: https://www.instructables.com/id/Why-Do-We-Want-to-Make-a-Cat-Ramp-You-Might-Ask/",
                        Issues = new List<Issue> {
                            new Issue
                            {
                                Summary = "Get supplies: Hardware",
                                Description = Truncate(@"1. 1.5in/1.5in wood plank 100in
2. 5in X 3/4in plank 8 feet long. Use recycled wood when possible.
3. 6 2in screws.
4. 2in nails x 20
5. Dark stain small container.
6. Inexpensive car carpet x1", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Done,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Get supplies: Tools",
                                Description = Truncate(@"1. Hammer
2. Foam brushes x2
3. Tape measure
4. Hand saw.
5. Table saw
6. Drill
7. Staple Gun
8. Metal file or sand paper
9. Utility knife
10. Work gloves and safety glasses", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Done,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Marks for the First Cuts",
                                Description = Truncate(@"Mark the 1.5in X 1.5in wood as such:
20in x 4
6in x2
2in x 2", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Saw the Planks and Sand the Edges",
                                Description = Truncate(@"Use the metal file to take off the rough edges so you don't get a splinter", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Fix the Frame to the Platform",
                                Description = Truncate(@"Place the 8in platform an on the workbench.
Take the 2in and 6in pieces of 1.5 wood and make sure that they fit along with the legs.
Hammer in nails to fix the frame pieces to the platform.
Take a drill bit that is a little smaller than the screws and drill pilot holes (so the wood doesn't split).
Put the drill bit in the drill and make sure it is tight, you don't want it to fall out.
Drill the holes.
Screw in the 20in legs so that they are fixed to the frame.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 3,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Stabilize the Platform",
                                Description = Truncate(@"Drill in the pilot holes and add the screws to each leg.
This makes the platform stable.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 5,
                                Status = IssueStatus.Develop,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Add the Ramp to the Platform",
                                Description = Truncate(@"Lay the plank on the lip and use a cinder block (or something heavy) to keep it in place.
Drill the pilot holes at an angle into the frame and then use the 2 inch screws x4", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 3,
                                Status = IssueStatus.Develop,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Cut the Carpet So That It Fits on the The Platform and Ramp",
                                Description = Truncate(@"Measure out 5.5in pieces. Using your utility knife, cut the carpet in pieces to completely cover the top of the ramp and platform", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 3,
                                Status = IssueStatus.Develop,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Staple the Carpet to the Ramp",
                                Description = Truncate(@"Carefully align the cut carpet to the ramp.
Using your staple gun, staple in several places so that the carpet doesn't come up.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Apply the Stain Onto the Ramp",
                                Description = Truncate(@"Lay down a tarp.
Open the stain and be careful not to spill!
Use the foam brushes and use even strokes on the wood until entirely coated.
Apply more coats if needed and let sit over night.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium
                            }
                        }
                    },
                    new Project
                    {
                        Name = "Face Mask",
                        Description = "A.B. Mask This pattern is designed to fit in two ways. First, directly over the face, similar to a surgical mask. Second, the pleats expand, allowing the mask to fit over many models of N-95... Original: https://www.instructables.com/id/AB-Mask-for-a-Nurse-by-a-Nurse/",
                        Issues = new List<Issue> {
                            new Issue
                            {
                                Summary = "Get supplies",
                                Description = Truncate(@"Fat quarter of 100% cotton or other tightly woven material - the tighter the better
sewing machine
iron", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Done,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Print the Pattern",
                                Description = Truncate(@"https://drive.google.com/file/d/15IdBNXP8YYPPIz9EMEf35XM0HEJWUYxH/view
Cut out pattern. Cut along straight black lines and dotted black line.
Choose your fabric - at least 21in x 18in (Fat Quarter). Iron out wrinkles.
*I have updated the pattern print out to clarify dimensions of the cutout pattern. I have also included a screen shot of the print settings I used so pattern was true to size. Thank you!", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Done,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Fold Fabric",
                                Description = Truncate(@"Fold fabric right-side out with selvage edge touching - taco style. Square fabric.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Cut Binding and Ties",
                                Description = Truncate(@"Cut 5 x 1.5 inch wide strips from the width of fabric. Each strip should be around 20"" in length.The strips above were cut with the fabric folded in half.
Or, if you are cutting out of longer fabric you could cut 2 (1.5"" wide x 40"" long) and 1 (1.5"" wide x 20"" long) and save yourself a step piecing the binding together.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Refold Fabric and Cut Mask Face",
                                Description = Truncate(@"Open up and refold leftover fabric. Fold width-wise - burrito style. So selvage on top, selvage on bottom - fold evenly. Pin pattern on upper half of folded fabric. Dotted line of pattern aligned with fold. Cut around edges of pattern. Cut out notches.
Unpin pattern and move to lower half of folded fabric. Cut out second piece.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Stack and Sew",
                                Description = Truncate(@"Stack the 2 face mask pieces, face down. Pin in place.
Sew together using 1/2"" seam around all four sides.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Develop,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Iron in Pleats",
                                Description = Truncate(@"With pointed pointing away from you, front of fabric side down, bring bottom side of fabric up and over top side. The fold should be the imaginary line between the top notch on left to top notch on right. Press crease with hot iron. The pleats are 1/4 inch.
Next, fold fabric back down. The fold should be imaginary line between 2nd notch on left and 2nd notch on right. Press crease with hot iron.
Repeat for 3rd and 4th notches.
Repeat of 5th and 6th notches.
Once the pleats are ironed in the edges of the mask should measure 3"" - give or take.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Sew Pleats in Place",
                                Description = Truncate(@"Sew pleats into place using a 1/2"" seam. Both Left and Right side of mask face.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Mark and Sew Darts",
                                Description = Truncate(@"Fold mask face in half at the center fold. Front side of fabric together, wrong side of fabric facing you.
Align pattern and mark top and bottom darts with pin or pencil.
Sew along line. - I went over it twice for good measure.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Trim Excess",
                                Description = Truncate(@"Trim seams to 1/4 inch.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Prepare the Binding",
                                Description = Truncate(@"Take 2 strips and pin at 90 deg angles. Repeat with 2 more strips.
Sew strips together at 45 deg angle. Trim seams at 1/4 inch and press with iron.
Take 5th strip and cut in half.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Attach Side Binding",
                                Description = Truncate(@"With mask facing down - front side of fabric facing away, wrong side of fabric facing towards you - pin 1.5"" binding you cut in half to left and right side of mask. Binding should be face down. Edge of binding aligned with outermost edge of mask.
Sew in place, starting just above top of mask and stopping just below bottom of mask, using 1/4 inch seam.
Press seam open with iron.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Finish Side Binding",
                                Description = Truncate(@"Flip mask over. Right side of fabric facing you.
Fold 1/4 inch seam towards you from outside edge of binding. Wrap folded edge around side edge of mask.
Pin in place.
Sew along edge of binding.
Repeat on other side.
Trim excess.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Attach Top/Bottom Binding",
                                Description = Truncate(@"With mask face, wrong side of fabric facing you, pin 1.5 inch binding strips along top and bottom edges.
Sew in place using 1/4 inch seams. Start sewing just above one side of mask face and end just after opposite side of mask face.
Press open with iron.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Finish Top/Bottom Binding and Ties",
                                Description = Truncate(@"Trim ties even on both sides of mask.
Iron in 1/4 inch seam on top and bottom of mask ties.
Iron in 1/4 inch seam on end of mask ties.
Fold ties in half and pin in place.
Sew Binding and Ties.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium
                            }
                        }
                    },
                    new Project
                    {
                        Name = "Pan Fry the Perfect Steak",
                        Description = "One of my favorite meals to cook for myself is a pan fried steak. Steak is a tricky food to get right, but I have perfected my method for cooking one... Original: https://www.instructables.com/id/How-To-Pan-Fry-the-Perfect-Steak/",
                        Issues = new List<Issue> {
                            new Issue
                            {
                                Summary = "Get Tools and Ingredients",
                                Description = Truncate(@"Here is a list of supplies you will need to cook your steak.

Tools

A Stove
One frying pan suitable for the size of your steak
Tongs
a knife
a plate
A clock or timer

Ingredients

One steak
Olive oil
Butter
Salt
Pepper
Fresh Garlic (or Garlic Powder)", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Done,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Shop for a Steak",
                                Description = Truncate(@"The first step is to locate the steak that you wish to cook. I always buy my steak at Tacoma Boys. They have a quality meat selection. It is a bit more expensive, but in my opinion, it is worth it.
The steak I chose was a 8oz Kobe Petite Sirloin steak. It is small enough for one person and a relatively inexpensive cut of meat. Find a steak that looks tasty to you! If you have the money for a nice New York Steak go for it, but for this tutorial we will be working with a petite sirloin steak.
While you are at the store, make sure you have the rest of your ingredients such as olive oil, butter, salt, pepper, and garlic. A grocery store is a perfect opportunity to pick up some fresh garlic if you prefer that to garlic powder.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Done,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Prepare the Meat",
                                Description = Truncate(@"When you get home you must get the meat out and let it warm up. When it is sitting in the grocery store, it is very cold and you do not want to cook a cold steak.
First pull the steak out of the butcher paper and let it rest on a plate. While it is sitting, use the salt and pepper to season it. Cover all sides with a good amount of seasoning.
Usually give the steak about 20 minutes to warm up. It is important to let the meat warm because when you cook it in the pan it will cook more evenly. You do not want a cold center.
While the steak is warming up, this is a good time to get the rest of your tools and ingredients ready. Place the pan on a burner and put it on high heat. Before heating, poor enough olive oil in the pan to coat the entire bottom. You want plenty of oil in the pan for the next step of the process.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Seer the Steak",
                                Description = Truncate(@"This next step is very crucial and can be dangerous. At this point, the pan should be very hot. You will use the tongs to place the steak into the hot oil. At these high temperatures there will be a lot of oil splatter so be careful when maneuvering the steak around in the pan.
When you place the steak in the pan begin timing the cooking for 1 Minute.
After a Minute has passed, flip it to the other side for 1 Minute.
After that minute has passed, flip the steak on its side and sear the edge until it is colored like the rest of the meat. do this for both sides. Tilt the pan so that the oil and juices run down to one side and use that to cook the edge of the steak. Refer to the photo for an example.
You will continuously be turning the steak for 1 Minute intervals until you feel that it is well done enough. This is all dependent on your wellness preference and the thickness of your steak. This will bring us to our next step.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Cook the Steak",
                                Description = Truncate(@"At this point, the steak has been seared on all sides, locking in the juices of the meat. Turn down the heat of your stove to medium.
Now comes the process of cooking through the meat to your preferred wellness. There is no exact science to this because of the variables of thickness and stove heat so you will just have to check the meat often to make sure it is not over or under cooked. For this demonstration, I cooked my steak to a medium wellness with some pink left in the middle.
Now that the heat is backed off, continue cooking the steak on each side for 1 Minute intervals.
Now it is time to add the garlic and butter. Cut off a nice healthy chunk of butter and throw it in the pan along with a generous amount of garlic. I used garlic powder because I didn't have any fresh garlic at the time. Allow the meat to soak in the greasy tasty goodness as you continue turning it. Keep in mind this is how to make the Perfect Steak, not a healthy steak.
I cooked my steak for 8 total minutes, flipping each minute, to get a medium wellness. Again, I have to be clear that variables in steak size and stove heat means that this may not give you the same result. Use the tongs to check the firmness of the meat. If it feels like it is beginning to firm up, then it is probably reaching a medium wellness.
After you have cooked it long enough, it is time to pull it from a pan and place it on a clean plate.", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Test,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Rest the Meat",
                                Description = Truncate(@"You have finished cooking the steak and are about to devour it but RESIST!
You must let the meat rest before cutting into it. The process known as resting, allows for all of the juices of the meat to lock inside the steak. This gives your steak better flavor.
Allow the steak to rest for 5 minutes. If you become impatient, find a beer of your choice (if you are of age), and have a drink!", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.Develop,
                                Priority = Priority.Medium
                            },
                            new Issue
                            {
                                Summary = "Eat and Enjoy",
                                Description = Truncate(@"You have been patient. You have waited five minutes. You are now ready to consume your amazing, and surprisingly inexpensive steak!
This steak requires no sauces. Sauce would only ruin the great flavors that you have created today in your pan.
Steamed vegetables and a cold beer also work as great sides to your meat masterpiece. Enjoy!", 300),
                                IssueType = IssueType.Task,
                                Storypoints = 2,
                                Status = IssueStatus.New,
                                Priority = Priority.Medium
                            }
                        }
                    }
                );
                context.SaveChanges();
            }
        }

        private static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}