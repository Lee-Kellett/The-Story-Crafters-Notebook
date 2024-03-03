Imports System.Xml
Imports Microsoft.VisualBasic.FileIO

Public Class Form1

    Private Sub ReadThisFirst()
        'Program by Lee Kellett
        'Last edit made: 27/08/2021

        'Note for Review: 
        '- For some reason lone underscores are automatically hidden due To Formatting settings.

        'Notes for SortArraysNewestFirst: 
        ' A temp bucket is my term for a variable used in a procedure to swap the contents of 2 variables: 
        '  Bucket A contains contA
        '  Bucket B contains contB
        '  Bucket C is our temp bucket
        '  1) Transfer contA from A to C
        '  2) Transfer contB from B to A
        '  3) Transfer ContA from C to A

        'Notes for btnLoad_Click: 
        ' In the mid function the 1st 39 = the distance from left to start extracting text
        ' and the 2nd 39 = the distance from left to stop extracting text.

    End Sub

    'Arrays for displaying entry data
    Dim strCategories() As String
    Dim strTempDate As String
    Dim dtDates() As Date
    Dim strNotes() As String

    Dim intEntryNum As Integer = 0

    'This sub handles the "Create Entry" button
    Private Sub btnCreateEntry_Click(sender As Object, e As EventArgs) Handles btnCreateEntry.Click

        'Dim variables
        Dim strCategory As String
        Dim strDate As String
        Dim strNotes As String

        'Assign variables
        strCategory = cbxCategories.SelectedItem
        strDate = dtpOccurrence.Value.Date
        strNotes = txbNotes.Text

        'All functions performed on the condition that Validation = true
        If ExistanceValidation() = True Then

            'If it does not exist we need to write the start element for the xml. If it already exists, we dont.
            If Not IO.File.Exists("Records.xml") Then

                'Load the XML file as a filestream so that we can append to it instead of overwriting
                Dim xmlFile As IO.FileStream = New IO.FileStream("Records.xml", IO.FileMode.Append)

                'From here on we will call on "writer" when we want to append / edit the file
                Dim writer As New XmlTextWriter(xmlFile, System.Text.Encoding.UTF8)
                writer.Formatting = Formatting.Indented
                writer.Indentation = 2

                'Only write the start element if the document did not already exist
                'If writeStart Then
                writer.WriteStartElement("Records")
                'End If
                'This calls on a custom function
                CreateXMLRec(strCategory, strDate, strNotes, writer)

                'If writeStart Then
                writer.WriteEndElement()
                'End If
                writer.Close()
                MsgBox("Entry saved successfully")

            Else
                'This section applies to scenarios where a record already exists

                AppendXMLRec(strCategory, strDate, strNotes)
                MsgBox("Entry saved successfully")

            End If

            'Clear fields to prevent accidental repeated posting

            'Resetting the combobox value
            cbxCategories.SelectedItem = "Categories"
            'Resetting the date/time picker value
            dtpOccurrence.Value = Today.Date
            'Resetting the textbox value
            txbNotes.Text = ""

        End If


    End Sub

    'The following function creates a new "Records.xml" file
    Private Function CreateXMLRec(ByVal strIncomingCategory As String, ByVal strIncomingDate As String,
                                  ByVal strIncomingNotes As String, ByVal writer As XmlTextWriter)

        'This function generates the open tag / start element of the new file seen as: <Entry>
        writer.WriteStartElement("Entry")

        'The following 3 functions create the individual xml element containing the players name
        'E.G. <Entry>[Enter name here]</Entry> as it would appear on the file

        'This writes <Category> which opens the element
        writer.WriteStartElement("Category")
        'This writes the contents of the category string 
        writer.WriteString(strIncomingCategory)
        'This writes </Category> which closes the element
        writer.WriteEndElement()

        'This writes the details about the date the relevent event occured
        writer.WriteStartElement("Date")
        writer.WriteString(strIncomingDate)
        writer.WriteEndElement()

        'This writes the notes about the event
        writer.WriteStartElement("Notes")
        writer.WriteString(strIncomingNotes)
        writer.WriteEndElement()

        'This closes the entry with </Entry>
        writer.WriteEndElement()

    End Function

    'The following function makes ammendments to the existing xml doc
    Private Function AppendXMLRec(ByVal strIncomingCategory As String, ByVal strIncomingDate As String,
                                  ByVal strIncomingNotes As String)

        'Environment.NewLine allows the text in the "newPlayer" string to be read as having miltiple lines
        Dim cr As String = Environment.NewLine
        Dim newEntry As String

        newEntry =
         "<Entry>" & cr &
         "    " & "<Category>" & strIncomingCategory & "</Category>" & cr &
         "    " & "<Date>" & strIncomingDate & "</Date>" & cr &
         "    " & "<Notes>" & strIncomingNotes & "</Notes>" & cr &
         "  " & "</Entry>"

        'xd refers to the XML doc we are referrencing
        Dim xd As New XmlDocument()
        'The .load function specifies which xml doc we are using
        xd.Load("Records.xml")

        'Create a new XmlDocumentFragment for our document.
        Dim docFrag As XmlDocumentFragment = xd.CreateDocumentFragment()
        'The Xml for this fragment is our newEntry string.
        docFrag.InnerXml = newEntry
        'The root element of our file is found using the DocumentElement property of the XmlDocument.
        Dim root As XmlNode = xd.DocumentElement
        'Append our new Person to the root element.
        root.AppendChild(docFrag)
        'Save the Xml doc at the end.
        xd.Save("Records.xml")

    End Function

    'This sub handles the "Load Entry List" button
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click

        'Check whether the Records file exists
        If FileSystem.FileExists("Records.xml") Then

            'Remove all already existing items from the listbox
            lsbDisplay.Items.Clear()

            'Add Default elements
            lsbDisplay.Items.Add("Organisation: Newest First")
            lsbDisplay.Items.Add("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -")
            lsbDisplay.Items.Add("")

            Dim m_xmld As XmlDocument
            'Dim m_nodelist As XmlNodeList

            Dim strEntryHeader As String
            Dim strEntryBody As String

            'Procudure, replace standard variables with arrays: 
            ' Dim a category array with number of slots corresponding to number of entries
            ' Note: array counter starts at 0
            ' Do the same for the notes & the date variable
            '
            ' Replace strCategory with the category array etc
            ' Do the same for the notes & the date variable

            m_xmld = New XmlDocument()
            'Here we load the file so that it can be referenced later in the program
            m_xmld.Load("Records.xml")
            'The nodelist creates list objects stored under the tag entry
            Dim m_nodelist As XmlNodeList = m_xmld.SelectNodes(".//Records/Entry")

            'This first FOR EACH loop is to get the length of the XML file so as to ReDim the arrays
            'so they are ready for data.
            For Each m_node As XmlNode In m_nodelist
                intEntryNum += 1
            Next

            'Here we ReDim the arrays based on the previous FOR EACH loop
            'We flag it as intEntryNum - 1 as ReDimming does not set length instead it sets the highest
            'index of the array (we had issues with blank array entries as arrays start at 0)
            ReDim strCategories(intEntryNum - 1)
            ReDim strNotes(intEntryNum - 1)
            ReDim dtDates(intEntryNum - 1)

            'We could set the intEntryNum to - 1 before the loop, but this opens up the possiblilty for _
            'bugs in our sorting algorithm below.

            'Here we reset the number of entries to be reused in the final XML reading below
            intEntryNum = 0

            'This FOR Each loop decides how many times to run based on how many entries found under <Entry>
            For Each m_node As XmlNode In m_nodelist

                strCategories(intEntryNum) = m_node.Item("Category").InnerText
                dtDates(intEntryNum) = m_node.Item("Date").InnerText
                strNotes(intEntryNum) = m_node.Item("Notes").InnerText

                intEntryNum += 1
            Next

            'Here we call the sub where we order the entry data by date
            SortArraysNewestFirst()

            For i As Integer = 0 To strNotes.Length - 1

                'This transfers all previous strings to a set of strings of similar name
                strEntryHeader = "Type: " & strCategories(i) & "      " & "Date: " & dtDates(i)
                strEntryBody = "Notes: " & strNotes(i)

                'The IF statement decides whether applying word wrap is neccesary based on the strings word count
                If strEntryBody.Length > 39 Then
                    'This section is triggered when modification to text IS necessary

                    Dim strEntryBodyP1 As String
                    Dim strEntryBodyP2 As String

                    Dim blnSpaceFound As Boolean
                    Dim intSpaceNumChecked As Integer
                    Dim strSpaceTransferString As String

                    'Procedure: 
                    'Seperate the string into 2 strings, each = or < 40 characters

                    'Extract text < 40 and assign to "strEntryBodyP1"
                    strEntryBodyP1 = Microsoft.VisualBasic.Left(strEntryBody, 39)
                    'Extract text > 39 and < 78 and assign to "strEntryBodyP2"
                    strEntryBodyP2 = Mid(strEntryBody, 39, 39)

                    'There is a bug where the last character in strEntryBodyP1 is the same as the 1st in P2
                    'This should fix it: 
                    strEntryBodyP2 = Microsoft.VisualBasic.Right(strEntryBodyP2, Len(strEntryBodyP2) - 1)

                    'The following is a draft of a sequence for searching for spaces, 
                    'the loop would need to: find the first space from the right of bodyP1, 
                    'remove the characters between those 2 points and add them to the end of bodyP2

                    blnSpaceFound = False
                    intSpaceNumChecked = 0
                    strSpaceTransferString = ""

                    'While blnSpaceFound = False
                    '
                    '  Search strEntryBodyP1 from the right side
                    '  Check if the character is a [space]
                    '
                    '  IF it is THEN 
                    '    blnSpaceFound = True
                    '  intSpaceNumChecked += 1
                    '  ELSE 
                    '    blnSpaceFound = False
                    '  END IF
                    '  
                    'End While

                    'Extract [intSpaceNumChecked] characters from the right side of the P1 string
                    'Give that value to strSpaceTransferString
                    'Attatch the value of strSpaceTransferString to the left end of the P2 string

                    strEntryBodyP1 = strEntryBodyP1 + "-"

                    'This puts the text in the listbox
                    lsbDisplay.Items.Add(strEntryHeader)
                    lsbDisplay.Items.Add(strEntryBodyP1)
                    lsbDisplay.Items.Add(strEntryBodyP2)
                    lsbDisplay.Items.Add("")

                Else
                    'This section is triggered when validation is NOT necessary

                    'This puts the text in the listbox
                    lsbDisplay.Items.Add(strEntryHeader)
                    lsbDisplay.Items.Add(strEntryBody)
                    lsbDisplay.Items.Add("")

                End If

            Next

            'Reset the length of intEntryNum
            intEntryNum = 0

        Else

            'Send message if file does not exist and end message
            MsgBox("File does not exist, create 1st entry to remedy",
                   MessageBoxButtons.OK, "File Load Error")

        End If

    End Sub

    'The Following sub sorts data whithin the entry arrays by date (newest first)
    Private Sub SortArraysNewestFirst()
        'This is a simple sort tool based on the date array

        'Possible errors in this function:
        '- Might not automatically convert from Date to String
        '- Might not like comparing strings 
        '- If these have to be converted manually then use (cStr(THING) to convert to string)

        If intEntryNum <> 0 And intEntryNum <> -1 Then
            'For some reason the IF statement breaks if we try to set the condition to < 1
            'So we're doing this:

            'This loop checks if each number has been sorted by sorting them
            For i As Integer = 0 To intEntryNum - 1

                'We are sorting biggest to smallest
                'We assume that the number at 'i' is the biggest number at the start of each loop
                Dim intBiggestNum As Integer = i

                'This loop compares the current number to the numbers 
                For j As Integer = i + 1 To intEntryNum - 1

                    'j = i + 1

                    If dtDates(j) > dtDates(intBiggestNum) Then

                        'If the number being compared is bigger then the previous number then 
                        'it Is Now the biggest number
                        intBiggestNum = j

                    End If

                Next

                'Variable swaping using temp-buckets

                'These are our temp-buckets
                Dim strTempDate As String = dtDates(i)
                Dim strTempNote As String = strNotes(i)
                Dim strTempCategory As String = strCategories(i)

                'We have now swaped the values of the index with the values at the largest number index
                dtDates(i) = dtDates(intBiggestNum)
                strNotes(i) = strNotes(intBiggestNum)
                strCategories(i) = strCategories(intBiggestNum)

                'The index that previously had the largest number now 
                'needs to have the values in our temp buckets
                dtDates(intBiggestNum) = strTempDate
                strNotes(intBiggestNum) = strTempNote
                strCategories(intBiggestNum) = strTempCategory

            Next

        Else
            MsgBox("intEntryNum = 0 or 1, congradulations, you've acheived the impossible, consult an IT person",
                   MessageBoxButtons.OK, "Processing Error")

        End If

    End Sub

    'The following function checks whether the input fields are empty or not
    Private Function ExistanceValidation()

        'I'm using a broad IF statement here because I'm too lazy to implement an easier method
        If cbxCategories.SelectedIndex < 0 And txbNotes.Text = "" Then

            'Combobox and textbox combined validation
            MsgBox("No item has been selected from the combobox and the textbox is empty",
                   MessageBoxButtons.OK, "Data Input Error")

            'This will end the function
            Return False

        Else

            'Combobox individual validation
            If cbxCategories.SelectedIndex < 0 Then
                'No item picked
                MsgBox("No item has been selected from the combobox", MessageBoxButtons.OK,
                       "Data Input Error")

                'This will end the function
                Return False

            End If

            'Textbox individual validation
            If txbNotes.Text = "" Then
                'Field is empty
                MsgBox("The textbox is empty", MessageBoxButtons.OK, "Data Input Error")

                'This will end the function
                Return False

            End If

        End If

        Return True

    End Function

    'This sub sends a pop-up when the label is clicked
    Private Sub lblPrivacyInfo_Click(sender As Object, e As EventArgs) Handles lblPrivacyInfo.Click

        'Structure: 

        'MessageBox.Show( [Insert text here] + _
        '                 [here] + _ 
        '                 [and also here], _ 
        '                 [Title], [Button type], [Icon] )

        MessageBox.Show("The Storycrafter's Notebook is a record creation and retrieval program by Lee Kellett. " +
               "This program does not employ any form of data encryption or password protection and therefore is not suitable for storing personal or sensitive information. " +
               "All files created by the program are stored locally.",
                   "About this program", MessageBoxButtons.OK, MessageBoxIcon.Question)

    End Sub
End Class
