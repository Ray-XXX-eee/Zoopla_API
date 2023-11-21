Feature: Pofanity methods API Testing
 
 @xml @noSlang
  Scenario: Verify xml endpoint without slang
    Given the input text is "bastard xml"
    When the user calls "xml" endpoint
    Then the response should contain valid XML
    And the response should not contain asterix 
  
  @xml @slang
  Scenario: Verify xml endpoint with slang
    Given the input text is "bastard xml"
    When the user calls "xml" endpoint
    Then the response should contain valid XML
    And the response should contain asterix

  @json @noSlang
  Scenario: Verify json endpoint without slang
    Given the input text is "no slang json"
    When the user calls "json" endpoint
    Then the response should contain valid JSON
    And the response should not contain asterix 

  @json @slang
  Scenario: Verify json endpoint with slang
    Given the input text is "bastard json"
    When the user calls "json" endpoint
    Then the response should contain valid JSON
    And the response should contain asterix
  
  @txt @noSlang
  Scenario: Verify plain endpoint without slang
    Given the input text is "no slang text"
    When the user calls "plain" endpoint
    Then the response should contain valid TXT
    And the response should not contain asterix 

  @txt @slang
  Scenario: Verify plain endpoint with slang
    Given the input text is "bastard text"
    When the user calls "plain" endpoint
    Then the response should contain valid TXT
    And the response should contain asterix

  @txt @slang
   Scenario: Verify profanity endpoint with slang
    Given the input text is "bastard endpoint"
    When the user calls containsprofanity endpoint
    Then the response should contain  True value

    @bool @noSlang
   Scenario: Verify profanity endpoint without slang
    Given the input text is "normal endpoint"
    When the user calls containsprofanity endpoint
    Then the response should contain  False value



    