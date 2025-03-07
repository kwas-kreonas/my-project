describe('Contacts App Tests', () => {
    
    beforeEach(() => {
        cy.visit('http://localhost:5173/'); // Заміни URL на актуальний для твого додатку
    });

    it('Додає новий контакт', () => {
        cy.get('[data-cy=add-contact]').click();
        cy.get('[data-cy=name-input]').type('John Doe');
        cy.get('[data-cy=phone-input]').type('1234567890');
        cy.get('[data-cy=submit-button]').click();
        
        // Перевіряємо, що контакт додано
        cy.contains('John Doe').should('be.visible');
        cy.contains('1234567890').should('be.visible');
    });

    it('Редагує існуючий контакт', () => {
        cy.contains('John Doe').parent().find('[data-cy=edit-button]').click();
        cy.get('[data-cy=name-input]').clear().type('Jane Doe');
        cy.get('[data-cy=phone-input]').clear().type('0987654321');
        cy.get('[data-cy=submit-button]').click();

        // Перевіряємо, що контакт оновлено
        cy.contains('Jane Doe').should('be.visible');
        cy.contains('0987654321').should('be.visible');
    });

    it('Видаляє контакт', () => {
        cy.contains('Jane Doe').parent().find('[data-cy=delete-button]').click();

        // Перевіряємо, що контакт зник
        cy.contains('Jane Doe').should('not.exist');
    });

    it('Сортує контакти за іменем', () => {
        // Додаємо декілька контактів
        cy.get('[data-cy=add-contact]').click();
        cy.get('[data-cy=name-input]').type('Alice');
        cy.get('[data-cy=phone-input]').type('1111111111');
        cy.get('[data-cy=submit-button]').click();

        cy.get('[data-cy=add-contact]').click();
        cy.get('[data-cy=name-input]').type('Bob');
        cy.get('[data-cy=phone-input]').type('2222222222');
        cy.get('[data-cy=submit-button]').click();

        // Натискаємо кнопку сортування
        cy.get('[data-cy=sort-button]').click();

        // Перевіряємо порядок елементів
        cy.get('[data-cy=contact-list] li').first().should('contain', 'Alice');
        cy.get('[data-cy=contact-list] li').last().should('contain', 'Bob');
    });
});
