export interface CourseDetail {
    id: number;
    title: string;
    description: string;
    status: string;
    courseLevel: string;

    isApproved?: boolean;
        discount: number;
    price: number;
    duration: number;
    language: string;
    imageUrl: string | null;
    videoUrl: string | null;
    noSubscribers: number;
    isFree: boolean;
    bestSeller?: string;
    currentPrice: number;
    rating: number;
    subCategory: {
        id: number;
        createdDate: string;
        modifiedDate: string | null;
        isDeleted: boolean;
        name: string;
        category: {
            id: number;
            createdDate: string;
            modifiedDate: string | null;
            isDeleted: boolean;
            name: string;
        };
    };
    instructor: {
        id: number;
        name: string;
        title: string;
        bio: string;
        totalCourses: number | null;
        totalReviews: number | null;
        totalStudents: number | null;
        wallet: number;
    };
    courseGoals: string[];
    courseRequirements: string[];
    sections: Section[];
}


export interface Section {
    id: number;
    title: string;
    duration: number;
    noLessons: number;
    lessons: Lesson[];
}

export interface Lesson {
  id: number;
  title: string;
  duration: number;
  type: string;
  videoUrl: string | null;
  articleContent: string | null;
}

export interface CourseContent{
  courseId: number;
  currentSectionId: number;
  currentLessonId: number;
  sections: Section[];

}

export const dummyCourseDetails: CourseDetail = {
    id: 1,
    title: "JavaScript",
    description: "The complete JavaScript course from zero to hero",
    status: "1",
    courseLevel: "All Levels",
    discount: 50,
    price: 100,
    duration: 50,
    language: "English",
    imageUrl: null,
    videoUrl: null,
    noSubscribers: 1000,
    isFree: false,
    bestSeller: "Best Seller",
    currentPrice: 50,
    rating: 4.5,
    subCategory: {
        id: 1,
        createdDate: "2025-04-02T18:13:20.5721179+02:00",
        modifiedDate: null,
        isDeleted: false,
        name: "Programming",
        category: {
            id: 1,
            createdDate: "2025-04-02T18:13:20.5721868+02:00",
            modifiedDate: null,
            isDeleted: false,
            name: "Development"
        }
    },
    instructor: {
        id: 22222,
        name: "Instructor Instructor",
        title: "Super Awesome Title",
        bio: "bioheehhe",
        totalCourses: null,
        totalReviews: null,
        totalStudents: null,
        wallet: 0
    },
    courseGoals: ["goal1", "goal2"],
    courseRequirements: ["requirement1", "requiremetn2"],
    sections: [
        {
            id: 3,
            title: "section1",
            duration: 1,
            noLessons: 2,
            lessons: [
                {
                    id: 1,
                    title: "lesson1",
                    duration: 1,
                    type: "video",
                    videoUrl: null,
                    articleContent: null
                },
                {
                    id: 2,
                    title: "lesson2",
                    duration: 1,
                    type: "video",
                    videoUrl: null,
                    articleContent: null
                }
            ]
        },
        {
            id: 5,
            title: "section2",
            duration: 1,
            noLessons: 0,
            lessons: []
        },
        {
            id: 6,
            title: "section3",
            duration: 1,
            noLessons: 0,
            lessons: []
        }
    ]
};
