# Sample project to showcase remote API usage.

## Project Structure

### CatAggregatorApp

WebApi application calling remote rest endpoint to get people data.
Manipulates into a different view model and presents as contentresult

*endpoint*

**GET
`http://[hostname]:[port]/api/Cat/GetCatNamesByOwnerGender`**

*returns*

**Simple HTML ContentResult**

### CatAggregatorApp.Tests

Contains unit test cases for the project.