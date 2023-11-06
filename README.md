# GSP-Tech-Demo-2-Assessment-Project
Gameplay Systems Programming 2nd Tech Demo (3D First Person Horror)

# GSP Project Requirements

# Video:
1. 3-6 Minute video showcasing completed features (Maybe you can include parts where you show your code and describe a bit how it works)

# Tech Demo Requirements:
1. Interaction System with Tooltips [DONE]
2. Inventory System [DONE]
4. Subtitle Typewriter System with Voiceover [DONE]
6. Document Viewing System [DONE]
7. Keypad Puzzle [DONE]
   - All keys to display digit on-screen
   - Should require 4-digit code
   - LED lights should glow depending on right/wrong answer
   - Clear Key, Delete Key and Confirm Key

# Requirement Specifications:
1. Interaction System With Tooltips - When you look at an item, an outline shader should be displayed alongside a tooltip that shows what we can do with that item (ie pickup, open, pull, push, interact, read etc).
2. Inventory System - The visuals don’t matter. It can be UI-based or old-school horror. The layout is irrelevant, as long as you can pickup items, discard them and use them.
3. Subtitle Typewriter System with Voiceover - Each letter should be appended to subtitles at the bottom of the screen at set intervals. You should trigger the VO either manually (input) or through a triggerbox or after picking up an item. The VO should not be synced per letter, but rather simply played when the correct VA line is displayed too.
4. Document Viewing System - When you inspect one, you should have a black faded background and the item should be the main focus on the screen. You should add a functionality that allows us to display the text of the document in a much clearer font as an additional overlay on screen. Buttons should be rendered on the sides to indicate what to press to exit document viewing mode.
5. Keypad Puzzle - The keypad should glow when looked at and when the inspection occurs, the camera should zoom in and stick to the keypad itself. Then we should be in a completely different input mode.
   - There should be a LED indicator that flashes when you enter the code. Red for wrong code and green for correct code.
   - When entering the incorrect code DON’T immediately clear the digits, leave them dangling for a few seconds and make sure you have input lock.
   - When entering the correct code (up to you) make something happen!
   - If you want to do this in a much easier way, use UI, else read the next slide.

# Extra Challenges (NOT REQUIRED):
1. For the keypad, manually render/highlight the keypad buttons using a pseudo-grid system. Basically you’ll use an index that moves around the keys highlighting the one you are currently at. Pressing the interact button should then interact with each highlighted key.
2. Implement it so that you have both a first person mode and a third person mode, with a character you can control using an over-the-shoulder 3rd person camera, similar to the TPS demo we did in weeks 2-3. Use a new input string to toggle between the 2.
3. Implement gamepad support for Xbox360 and PS5 controllers specifically. Ensure that depending on the identified input your “button sprites” change. A button sprite is the tooltip that appears to prompt the user to press a button to interact / read etc. The button sprites thus need to dynamically change based on the identified input.
4. Make the room bigger and add a monster with AI that can chase you when it spots you.
5. Make documents pickupable and added on a separate journal inventory so you can read them at any time from anywhere.
6. Use scriptable objects for the inventory and any interactable item.
7. Ensure your entire project has a maintainability index of 90+.
