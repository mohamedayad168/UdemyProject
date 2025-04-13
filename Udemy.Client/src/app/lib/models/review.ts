export interface rating {
    rating: number;
    comment: string;
    date: Date;
    studentName: string; // Name of the user who wrote the review
}
export interface CourseRating {
    courseId: number;
    rating: number;
    totalReviews: number;
    instructorId: number;
    ratings: rating[];
}

export interface PostReview {
    courseId: number;
    rating?: number;
    comment?: string;
}


export const dummyRatings: CourseRating= {
    courseId: 1,
    instructorId: 1,
    rating: 4.5,
    totalReviews: 3,
    ratings: [
        {

            rating: 5,
            comment: "Great course!",
            date: new Date("2023-10-01"),
            studentName: "Alice"
        },
        {

            rating: 4,
            comment: "Very informative.",
            date: new Date("2023-10-02"),
            studentName: "Bob"
        },
        {

            rating: 3.5,
            comment: "Good, but could be better.",
            date: new Date("2023-10-03"),
            studentName: "Charlie"
        }
    ]
};
