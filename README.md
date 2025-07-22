# GSP-Tech-Demo-2-Assessment-Project
Gameplay Systems Programming 2nd Tech Demo (3D First Person Horror)

[<p align="center"><img src="https://img.youtube.com/vi/vv1ChbgNjwY/hqdefault.jpg" width="600" height="400"/></p>](https://www.youtube.com/embed/vv1ChbgNjwY)

## Insights

The making of a 3D horror game demo in Unity using C#. You can play the game here: https://themglegends.itch.io/secrets-of-solitude

## Requirements

The following requirements have been fully completed.

1. Interaction System with Tooltips
2. Inventory System
4. Subtitle Typewriter System with Voiceover
6. Document Viewing System
7. Keypad Puzzle
   - All keys to display digit on-screen
   - Should require 4-digit code
   - LED lights should glow depending on right/wrong answer
   - Clear Key, Delete Key and Confirm Key

## Requirements Specifications:
1. Interaction System With Tooltips - When you look at an item, an outline shader should be displayed alongside a tooltip that shows what we can do with that item (ie pickup, open, pull, push, interact, read etc).
2. Inventory System - The visuals don’t matter. It can be UI-based or old-school horror. The layout is irrelevant, as long as you can pickup items, discard them and use them.
3. Subtitle Typewriter System with Voiceover - Each letter should be appended to subtitles at the bottom of the screen at set intervals. You should trigger the VO either manually (input) or through a triggerbox or after picking up an item. The VO should not be synced per letter, but rather simply played when the correct VA line is displayed too.
4. Document Viewing System - When you inspect one, you should have a black faded background and the item should be the main focus on the screen. You should add a functionality that allows us to display the text of the document in a much clearer font as an additional overlay on screen. Buttons should be rendered on the sides to indicate what to press to exit document viewing mode.
5. Keypad Puzzle - The keypad should glow when looked at and when the inspection occurs, the camera should zoom in and stick to the keypad itself. Then we should be in a completely different input mode.
   - There should be a LED indicator that flashes when you enter the code. Red for wrong code and green for correct code.
   - When entering the incorrect code DON’T immediately clear the digits, leave them dangling for a few seconds and make sure you have input lock.
   - When entering the correct code (up to you) make something happen!
   - If you want to do this in a much easier way, use UI, else read the next slide.
