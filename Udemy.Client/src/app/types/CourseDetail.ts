export interface CourseDetail {
    id: number;
    createdDate: string;
    modifiedDate: string;
    title: string;
    description: string;
    courseLevel: string;
    discount: number;
    price: number;
    duration: number;
    language: string;
    imageUrl: string;
    videoUrl: string;
    noSubscribers: number;
    isFree: boolean;
    currentPrice: number;
    rating: number;
    bestSeller?:string;
    goals: string[];
    courseContent: {
      sections: {
        title: string;
        lessons: {
          title: string;
          duration?: number;
          type: string;
        }[];
      }[];
    };
    requirements: string[];
    totalReviews: number;
    totalStudents: number;
    subcategory: {
        id: number;
        title: string;
    };
    category: {
        id: number;
        title: string;
    };
    instructor: {
        id: number;
        name:string;
        bio: string;
        totalReviews: number;
        totalCourses: number;
        totalStudents: number;
    };
}

export const dummyCourseDetails: CourseDetail = {
  id: 1,
  createdDate: "2025-04-01T03:28:08.073Z",
  modifiedDate: "2025-04-01T03:28:08.073Z",
  title: "Introduction to TypeScript",
  description: "Learn the basics of TypeScript, a powerful typed superset of JavaScript.",
  courseLevel: "Beginner",
  discount: 10,
  price: 100,
  duration: 5, // in hours
  language: "English",
  imageUrl: "https://cdn.careers.tufts.edu/wp-content/uploads/sites/100/2021/09/udemy-480x252.png?v=95780",
  videoUrl: "https://example.com/course-video.mp4",
  noSubscribers: 1500,
  isFree: false,
  currentPrice: 90,
  bestSeller:"Best Seller",
  rating: 4.5,
  goals: ["Understand TypeScript basics", "Learn about interfaces and types", "Build a TypeScript project"],
  courseContent: {
      sections: [
          {
              title: "Getting Started",
              lessons: [
                  { title: "Introduction to TypeScript", duration: 10, type: "video" },
                  { title: "Setting up the Environment", duration: 15, type: "video" }
              ]
          },
          {
              title: "Core Concepts",
              lessons: [
                  { title: "Understanding Types", duration: 20, type: "video" },
                  { title: "Working with Interfaces", duration: 25, type: "video" }
              ]
          }
      ]
  },
  requirements: ["Basic JavaScript knowledge", "A computer with internet access"],
  totalReviews: 200,
  totalStudents: 1500,
  subcategory: {
      id: 101,
      title: "Programming Languages"
  },
  category: {
      id: 1,
      title: "Development"
  },
  instructor: {
      id: 1,
      name: "John Doe",
      bio: "An experienced software developer and instructor.",
      totalReviews: 500,
      totalCourses: 10,
      totalStudents: 20000
  }
};
