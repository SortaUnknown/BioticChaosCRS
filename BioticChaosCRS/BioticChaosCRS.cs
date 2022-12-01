using BepInEx;
using CustomRegions.Mod;

namespace BioticChaosCRS
{
    [BepInPlugin("HelloThere.BioticChaosCRS", "Biotic Chaos", "1.1")]
    public class BioticChaos : BaseUnityPlugin
    {
        public void OnEnable()
        {
            On.RainWorldGame.ctor += CtorPatch;
            On.SSOracleBehavior.PebblesConversation.AddEvents += PebbleConvoPatch;
            On.SLOracleBehaviorHasMark.MoonConversation.AddEvents += PearlPatch;
        }

        public static bool bcEnabled = false;
        
        static void CtorPatch(On.RainWorldGame.orig_ctor orig, RainWorldGame instance, ProcessManager manager)
        {
            orig.Invoke(instance, manager);

            bcEnabled = API.ActivatedPacks.TryGetValue("Biotic Chaos", out string p);
        }

        static void PebbleConvoPatch(On.SSOracleBehavior.PebblesConversation.orig_AddEvents orig, SSOracleBehavior.PebblesConversation instance)
        {
            if (!bcEnabled) { orig.Invoke(instance); }
            else
            {
                switch (instance.id)
                {
                    //  instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("...I'm sorry little one, but I can't seem to be able to read this."), 8));
                    //  instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("It's written in a complex internal language which my processors can barely<LINE>understand anymore."), 12));
                    case Conversation.ID.Pebbles_Red_Green_Neuron:
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Let us see..."), 10));
                        instance.events.Add(new SSOracleBehavior.PebblesConversation.PauseAndWaitForStillEvent(instance, instance.convBehav, 180));
                        instance.events.Add(new Conversation.TextEvent(instance, 50, instance.Translate("More slag keys..."), 15));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("But why?"), 10));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Why did he send another one?"), 20));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Didn't the last one succeed?"), 20));
                        instance.events.Add(new SSOracleBehavior.PebblesConversation.PauseAndWaitForStillEvent(instance, instance.convBehav, 15));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("However, it seems this delivery was not intended for me. Everything suggests<LINE>it was tailored for the specific predicaments of a friend of mine."), 25));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Her name is Looks to the Moon, and her state is considerably worse than mine.<LINE>She's a short distance to the east of here - much shorter than customary.<LINE>A circumstance that has led to some difficulties between us."), 35));
                        if (!instance.owner.oracle.room.game.IsStorySession || !instance.owner.oracle.room.game.GetStorySession.saveState.redExtraCycles)
                        {
                            instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("You are part of an uncountable amount of clones of yourself."), 10));
                            instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("All made with the same purpose.<LINE>All killed in different circumstances."), 12));
                            instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("You are now part of an exclusive elite.<LINE>The ones that have gotten so far as reaching my chamber."), 15));
                            instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("You have been given an extremely rare chance."), 8));
                            instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("You cannot fail now.<LINE>You MUST NOT fail now."), 9));
                            instance.events.Add(new SSOracleBehavior.PebblesConversation.PauseAndWaitForStillEvent(instance, instance.convBehav, 80));
                            instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("I must do whatever is in my hand to aid you."), 8));
                            instance.events.Add(new SSOracleBehavior.PebblesConversation.PauseAndWaitForStillEvent(instance, instance.convBehav, 10));
                            instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("I was not a medical facility even when the equipment was functioning,<LINE>but I will attempt to do something to buy you a little time."), 20));
                            instance.events.Add(new Conversation.SpecialEvent(instance, 0, "karma"));
                            instance.events.Add(new SSOracleBehavior.PebblesConversation.PauseAndWaitForStillEvent(instance, instance.convBehav, 20));
                        }
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Now get to Looks to the Moon, and give this to her."), 10));
                        instance.events.Add(new Conversation.TextEvent(instance, 30, instance.Translate("I have faith in you, little creature."), 30));
                        break;
                    case Conversation.ID.Pebbles_Red_No_Neuron:
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Another one?"), 10));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("But why?"), 10));
                        instance.events.Add(new SSOracleBehavior.PebblesConversation.PauseAndWaitForStillEvent(instance, instance.convBehav, 15));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Didn't the last one succeed?"), 15));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("..."), 15));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("I have seen you carrying a little device earlier, did you lose it?"), 13));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Or maybe you brought it to her already, is that so?"), 10));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("..."), 10));
                        instance.events.Add(new SSOracleBehavior.PebblesConversation.PauseAndWaitForStillEvent(instance, instance.convBehav, 10));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("For your own good, I hope that is the case."), 8));
                        instance.events.Add(new Conversation.TextEvent(instance, 15, instance.Translate("..."), 20));
                        instance.events.Add(new SSOracleBehavior.PebblesConversation.PauseAndWaitForStillEvent(instance, instance.convBehav, 25));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Then, she should be alright."), 7));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Congratulations.<LINE>You suceeded."), 10));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("You are really tired, aren't you?<LINE>You have done a good job."), 15));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("However, you will not last for much longer.<LINE>There is a disease growing inside you, just like me."), 17));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("For you, there is a solution."), 10));
                        instance.events.Add(new SSOracleBehavior.PebblesConversation.PauseAndWaitForStillEvent(instance, instance.convBehav, 10));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Go to the west past the Farm Arrays, and then down into the earth where the land fissures, as deep as you can reach."), 20));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("I will give you something that might be of help."), 13));
                        instance.events.Add(new Conversation.SpecialEvent(instance, 0, "karma"));
                        instance.events.Add(new SSOracleBehavior.PebblesConversation.PauseAndWaitForStillEvent(instance, instance.convBehav, 25));
                        instance.events.Add(new Conversation.TextEvent(instance, 10, instance.Translate("Now, you should leave."), 30));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("I must...resume my work."), 10));
                        break;
                    case Conversation.ID.Pebbles_Yellow:
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Another one, huh?"), 15));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("I wonder..."), 10));
                        instance.events.Add(new SSOracleBehavior.PebblesConversation.PauseAndWaitForStillEvent(instance, instance.convBehav, 25));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("I have been tracking your movements since you first fell down into the Outskirts.<LINE>I wonder what attracts you all so much to me."), 20));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("You crawl towards me desperately, taking on a journey against dangerous creatures and things you cannot even understand.<LINE>Things you will never be able to understand..."), 26));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("And then you come here and beg me to put you out of your suffering,<LINE>to free you from this loop you are stuck in, like all of us."), 20));
                        instance.events.Add(new SSOracleBehavior.PebblesConversation.PauseAndWaitForStillEvent(instance, instance.convBehav, 35));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("..."), 10));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Look at me.<LINE>I am old."), 20));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("I saw this world fall apart, I saw life become extint.<LINE>And I saw it rise, conquering all of these...new ecosystems, to call them so.<LINE>And it conquered me as well..."), 26));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Soon one of those creatures will mess with some array, or dig too deep into my structure...<LINE>...and it will be the end of me."), 17));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("I killed any that snuck too deep into the systems bus, but you.<LINE>You are always a nice visit.<LINE>You at least keep me from falling into desperation."), 22));
                        instance.events.Add(new SSOracleBehavior.PebblesConversation.PauseAndWaitForStillEvent(instance, instance.convBehav, 35));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("..."), 10));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Well, I guess I should do what you are here for, eh?<LINE>Find a solution for your problem."), 15));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("That is what we were made for, anyway."), 10));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("You must go to the west, past the Farm Arrays, where the land fissures, blah blah blah..."), 15));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Now you must leave."), 10));
                        instance.events.Add(new Conversation.TextEvent(instance, 10, instance.Translate("I appreciate this conversation, but I have other business to deal with."), 25));
                        instance.events.Add(new SSOracleBehavior.PebblesConversation.PauseAndWaitForStillEvent(instance, instance.convBehav, 15));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Also, on your way out please use the access shaft."), 25));
                        break;
                    case Conversation.ID.Pebbles_White:
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Impressive..."), 10));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Very rarely do I ever find one of you reaching my chambers<LINE>in this period of time..."), 15));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("The peak of a Biotic Rebalance event."), 20));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("The ecosystem changes, and you seem to be able to adapt to it rather well..."), 13));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Yes, I have been studying your kind closely for quite a while."), 10));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("The descendants of old messenger organisms,<LINE>naturally drawn to us iterators..."), 14));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("For countless cycles I've had to deal with your ancestors, sliding through my systems<LINE>and scratching through my arrays, all asking for the same thing..."), 25));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Well, I guess there is no point ranting about it, huh?"), 10));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Go west past the Farm Arrays, and then down into the earth, where the ancients built their<LINE>temples blah blah blah..."), 20));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("You little creatures get to simply walk into my chamber, receive Enlightenment,<LINE>and then just walk towards Ascension."), 20));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("I wish we Iterators were so fortunate."), 10));
                        instance.events.Add(new SSOracleBehavior.PebblesConversation.PauseAndWaitForStillEvent(instance, instance.convBehav, 15));
                        instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Goodbye now. I must resume my work."), 15));
                        break;
                    default:
                        orig.Invoke(instance);
                        break;
                }
            }
        }

        static void PearlPatch(On.SLOracleBehaviorHasMark.MoonConversation.orig_AddEvents orig, SLOracleBehaviorHasMark.MoonConversation instance)
        {
            if (!bcEnabled || instance.id != Conversation.ID.Moon_Pearl_Red_stomach) { orig.Invoke(instance); }
            else
            {
                instance.PearlIntro();
                instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("\"Slugcat Messenger ID: Unknown."), 0));
                instance.events.Add(new Conversation.TextEvent(instance, 10, instance.Translate("To be honest I do not longer know if these regular packages help you<LINE>or only prolong your suffering,<LINE>but I still hope to find a more permanent solution."), 0));
                instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("Hold in there Moon, help is on the way!\""), 30));
                instance.events.Add(new Conversation.TextEvent(instance, 40, instance.Translate("..."), 10));
                instance.events.Add(new Conversation.TextEvent(instance, 0, instance.Translate("What does this even mean?"), 20));
            }
        }
    }
}
