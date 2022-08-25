Clone the repo

I used VS (to clone) and then had to reopen it so it loaded correctly

Set multiple start-up projects
	Scorado.Ryan.Sudoku.Api
	Scorado.Ryan.Sudoku.WpfUi

Should build and run fine

The API should be set to http://localhost:5141 which the UI is hardcoded to




The UI allows you to set puzzle cells by setting the x position, y position and the puzzle cell value
(Where setting the bottom left cell to 1 would be setting x position to 0, y position to 0 and the puzzle value of the cell to 1)
Set these in the text boxes and then click the 'Set' button
Repeat this process to set a puzzle
There is no visual representation of the puzzle while setting the problem
When the puzzle is set click 'Get' which will return the solution in the grid
Clicking 'Get' without setting any puzzle cells will return the most natural solution for the solver




I did copy some of the code to solve the problem from a Sudoku solver I wrote around 2008 - you can have the source for this if you wish (so you know it's mine)
Just mentioning this as some of the solver code is not great - not very testable - some methods a bit long - bad naming. But the logic seems solid.
Other notes as mentioned in the email I sent
	-I'll focus on code clarity, maintainability and extensibility. I'll do a simple front end in WPF but won't bother with MVVM or anything testable, extensible or of a standard that I would normally use (for the front end), just a hook in to spike the API.
	-I'll make the API testable and write a few tests, I won't go for anywhere near acceptable test coverage, just prove it's testable.
Additionally
	-No authentication or authorisation
	-Cached memory store, which only currently allows for one problem at a time. This could be extended to use a SQL dB storing multiple problems for multiple users
	-No logging
	-The exception handling is a bit of a mess, but I just wanted to get this out to you and not second guess what you are looking for me to spend time on
	




	