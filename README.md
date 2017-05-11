# VS2010 UnitTest Coverage Analyzer
Imported from https://vczhtoolcoverage.codeplex.com/

# Features
* Load Visual Studio Code Coverage XML File (get this file by clicking "Export Results" in "Test->Windows->Code Coverage Results" in Visual Studio)
* Import saved filter
* Export current filter
* Filtering with and, or and predifined functions:
	* StartsWith
	* NotStartsWith
	* EndsWith
	* NotEndsWith
	* Matches (the same to System.Text.RegularExpressions.Regex)
	* NotMatches (the same to System.Text.RegularExpressions.Regex)
	* Contains
	* NotContains
	* Equal
	* NotEqual

Each item has a separated filter to control the visibilities of the child items. In the current version you should write filter as XML directly by your self. The format is simple, at least for programmers.

For example, you want to see items that starts with "abc" or "def", and ends with "ghi", you should use
```xml
<and>
  <or>
    <StartsWith>abc</StartsWith>
    <StartsWith>def</StartsWith>
  </or>
  <EndsWith>ghi</EndsWith>
</and>
```
