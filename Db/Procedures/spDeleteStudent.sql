CREATE OR ALTER PROCEDURE spDeleteStudent (
    @StudetId   UNIQUEIDENTIFIER
)
AS
    BEGIN TRANSACTION
        DELETE FROM
            [StudentCourse]
        WHERE
            [StudentId] = @StudetId

        DELETE FROM 
            [Student]
        WHERE
            [Id] = @StudetId
    COMMIT