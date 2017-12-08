using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingsManager : MonoBehaviour 
{

	public LineManager titleCardLM;

	// Use this for initialization
	void Start () 
	{
		if (GameInformation.TotalStrange > 600)
		{
			titleCardLM.sentences[12] = "What ensues can only be described as a panic.";
			titleCardLM.sentences[13] = "The film is brought before the governor, who issues a state of emergency and mobilizes the National Guard.";
			titleCardLM.sentences[14] = "The town of Wit’s End is swarmed with military vehicles and personnel.";
			titleCardLM.sentences[15] = "For a few days, the place is Armageddon. Arrests are made.";
			titleCardLM.sentences[16] = "Douglas Masters is killed in a firefight. The Maritime Museum is leveled.";
			titleCardLM.sentences[17] = "The pearl is reclaimed, and stored away. Or so they tell you.";
			titleCardLM.sentences[18] = "Those under the influence of Douglas and the pearl begin to act more and more like themselves.";
			titleCardLM.sentences[19] = "Your mother, Anne, Joseph--all come back to you, weathered and worn, but still alive.";
			titleCardLM.sentences[20] = "For now, it seems, Wit’s End is at peace.";
			titleCardLM.sentences[21] = "Or as peaceful as a creepy, coastal New England town can be, anyway.";
			titleCardLM.sentences[22] = "For the first time since being back, you feel happy to be home.";
		} else if (GameInformation.TotalStrange <= 600 && GameInformation.TotalStrange > 400)
		{
			titleCardLM.sentences[12] = "The police are unimpressed, to say the least.";
			titleCardLM.sentences[13] = "But they see the sincere worry and fear etched into your face, and they relent to send units of the highway patrol to check up on your story.";
			titleCardLM.sentences[14] = "You tell them not to, unless they’re heavily armed and ready for a fight--but they just laugh and reassure you that everything will be alright.";
			titleCardLM.sentences[15] = "But everything doesn’t turn out alright.";
			titleCardLM.sentences[16] = "The patrol units arrive in the town of Wit’s End, and within hours, go missing.";
			titleCardLM.sentences[17] = "After failing to check in, the Massachusetts State Police department sends a team to the town to investigate what happens.";
			titleCardLM.sentences[18] = "But those investigators disappear as well.";
			titleCardLM.sentences[19] = "With cause to mobilize a large force, the governor issues a state of emergency in the town of Wit’s End, and the National Guard arrives shortly.";
			titleCardLM.sentences[20] = "But their guns and bullets were no match for the… thing that emerged from the sea.";
			titleCardLM.sentences[21] = "News outlets began describing it as a “real Godzilla.” But you know what it is. And you know where it came from.";
			titleCardLM.sentences[22] = "And you know that now… it can’t be stopped.";
		} else 
		{
			titleCardLM.sentences[12] = "After watching the film, the police angrily shove you out of doors, yelling at you for wasting their time, threatening to arrest you for obstructing officers on duty.";
			titleCardLM.sentences[13] = "Defeated, and with no allies left, you wander aimlessly, wondering if there was anything you could have done better…";
			titleCardLM.sentences[14] = "Now the town, the people, your family and friends, are all lost.";
			titleCardLM.sentences[15] = "Lost to the same voice that’s been gnawing at the back of your mind, urging you to return home.";
			titleCardLM.sentences[16] = "To return to Wit’s End.";
			titleCardLM.sentences[17] = "As you approach the Maritime Museum, you see your mother, Anne, Joseph, even Alice, all standing in a semicircle.";
			titleCardLM.sentences[18] = "In the center stands Douglas Masters, holding the beautiful pearl.";
			titleCardLM.sentences[19] = "They open their arms to receive you.";
			titleCardLM.sentences[20] = "You walk to them.";
			titleCardLM.sentences[21] = "The pearl blinks.";
			titleCardLM.sentences[22] = "And you go home.";		
		}
	}
}
