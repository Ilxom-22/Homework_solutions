var reviewList = new ReviewList<IReview>();

reviewList.GetOverallReview();
Console.WriteLine();

var review1 = new Review(5, "I had an amazing experience! " +
    "The service was impeccable, and the food was absolutely delicious. I can't wait to come back again.");

var review2 = new Review(5, "What a find! This place exceeded all my expectations. Cozy ambiance, " +
    "friendly staff, and the flavors in every dish were a delightful surprise.");

var review3 = new Review(5, "Visited based on recommendations, and I'm so glad I did. " +
    "The atmosphere was charming, and the attention to detail was evident. This spot deserves all the praise it gets.");


var report1 = new CrashReport(3, "Encountered a sudden crash while running SystemShock software. " +
    "Error message: 'Fatal Error - Memory Access Violation.' Please investigate and provide a fix.", "");

var report2 = new CrashReport(2, "While using GameMaster app, experienced a freeze followed by a crash. " +
    "No specific error message displayed. App became unresponsive and required a restart.", "");

var report3 = new CrashReport(5, "MediaSync crashed unexpectedly during video file conversion. " +
    "Error details: 'Exception code: 0xc0000005 - Access Violation.' Urgently need assistance to prevent data loss.", "");


reviewList.Add(review1);
reviewList.Add(review2);
reviewList.Add(review3);
reviewList.Add(report1);
reviewList.Add(report2);
reviewList.Add(report3);

Console.WriteLine(reviewList.GetReview(review2.Id).Message);
Console.WriteLine();

Console.WriteLine(reviewList.GetReview(report1.Message).Message);
Console.WriteLine();

reviewList.Update(report3.Id, 1, "MediaSync crashed unexpectedly during video file conversion. " +
    "Error details: 'Exception code: 0xc0000005 - Access Violation.' Urgently need assistance to prevent data loss.");

reviewList.GetOverallReview();
