Feature: API CRUD  
  Scenario: Obtener un usuario por ID
    Given se solicita el usuario con ID 1
    Then el API debería devolver código 200
    And el usuario debería llamarse "Leanne Graham"