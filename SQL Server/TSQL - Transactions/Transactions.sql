USE [Blog]

CREATE PROCEDURE AddCommentMark
  @comid AS int,
  @userid AS int,
  @mark AS int
AS
BEGIN
  BEGIN TRAN CommentMark

  INSERT INTO CommentRating(IdComment, IdUser, Mark)
  VALUES (@comid, @userid, @mark)

  IF(@@ERROR != 0)
  BEGIN
    PRINT 'Error in insert'
    ROLLBACK TRAN CommentMark
  END
  ELSE
  BEGIN

    PRINT 'Insert ok'
    UPDATE Comments
    SET Rating = (
      SELECT CAST(SUM(Mark) AS float) / COUNT(*)
      FROM Comments INNER JOIN CommentRating
      ON Comments.Id = CommentRating.IdComment
      WHERE  Comments.Id = @comid
    )
    WHERE  Comments.Id = @comid

    IF(@@ERROR != 0)
    	BEGIN
      		PRINT 'Error in update'
      		ROLLBACK TRAN CommentMark
    	END
    ELSE
    	BEGIN
      		PRINT 'update ok'
      		DECLARE @avg_comment_rate AS FLOAT 
			DECLARE @avg_post_rate AS FLOAT 
			
			SET @avg_comment_rate = (
				SELECT CAST(SUM(C.Rating) AS FLOAT) / COUNT(*)
				FROM Comments AS C
				INNER JOIN CommentRating AS CR
				ON C.IdUser = CR.IdUser 
				WHERE C.IdUser = @userid
			)
			SET @avg_post_rate = (
				SELECT CAST(SUM(P.Rating) AS FLOAT) / COUNT(*)
				FROM Posts AS P
				INNER JOIN PostRating AS PR
				ON P.IdUser = PR.IdUser 
				WHERE P.IdUser = @userid
			)
			UPDATE Users
			SET Rating = (@avg_comment_rate + @avg_post_rate) / 2
			WHERE Id = @userid

			IF @@ERROR != 0
				BEGIN
					PRINT 'ERROR IN UPDATING USER''S AVG RATING !'
					ROLLBACK TRANSACTION CommentMark
				END
			ELSE 
				BEGIN
					PRINT 'UPDATING USER''S AVG RATING WAS SUCCESFULLY FINISHED TRANSACTION!'
					COMMIT TRANSACTION CommentMark
				END
    	END
  END
END

CREATE PROCEDURE AddPostMark
  @postid AS int,
  @userid AS int,
  @mark AS int
AS
BEGIN
  BEGIN TRAN PostMark

  INSERT INTO PostRating(IdPost, IdUser, Mark)
  VALUES (@postid, @userid, @mark)

  IF(@@ERROR != 0)
  BEGIN
    PRINT 'Error in insert'
    ROLLBACK TRAN PostMark
  END
  ELSE
  BEGIN

    PRINT 'Insert ok'
    UPDATE Posts
    SET Rating = (
      SELECT CAST(SUM(Mark) AS float) / COUNT(*)
      FROM Posts INNER JOIN PostRating
      ON Posts.Id = PostRating.IdPost
      WHERE  Posts.Id = @postid
    )
    WHERE  Posts.Id = @postid

    IF(@@ERROR != 0)
    	BEGIN
      		PRINT 'Error in update'
      		ROLLBACK TRAN PostMark
    	END
    ELSE
    	BEGIN
      		PRINT 'update ok'
      		DECLARE @avg_comment_rate AS FLOAT 
			DECLARE @avg_post_rate AS FLOAT 
			
			SET @avg_comment_rate = (
				SELECT CAST(SUM(C.Rating) AS FLOAT) / COUNT(*)
				FROM Comments AS C
				INNER JOIN CommentRating AS CR
				ON C.IdUser = CR.IdUser 
				WHERE C.IdUser = @userid
			)
			SET @avg_post_rate = (
				SELECT CAST(SUM(P.Rating) AS FLOAT) / COUNT(*)
				FROM Posts AS P
				INNER JOIN PostRating AS PR
				ON P.IdUser = PR.IdUser 
				WHERE P.IdUser = @userid
			)
			UPDATE Users
			SET Rating = (@avg_comment_rate + @avg_post_rate) / 2
			WHERE Id = @userid

			IF @@ERROR != 0
				BEGIN
					PRINT 'ERROR IN UPDATING USER''S AVG RATING !'
					ROLLBACK TRANSACTION PostMark
				END
			ELSE 
				BEGIN
					PRINT 'UPDATING USER''S AVG RATING WAS SUCCESFULLY FINISHED TRANSACTION!'
					COMMIT TRANSACTION PostMark
				END
    	END
  END
END