import * as yup from 'yup';

export const doctorsValidation = yup.object({
    doctorName: yup.string().required(),
    doctorSurname: yup.string().required(),
    doctorSummary: yup.string().required(),
    file: yup.mixed().when('doctorImg', {
        is: (value: string) => !value,
        then: yup.mixed().required('Please provide an image')
    })
});
export const exercisesValidation = yup.object({
    exerciseItemTitle: yup.string().required(),
    exerciseItemDescription: yup.string().required(),
    file: yup.mixed().when('exerciseItemImg', {
        is: (value: string) => !value,
        then: yup.mixed().required('Please provide an image')
    })
});
export const foodValidation = yup.object({
    nutritionFoodItemTitle: yup.string().required(),
    nutritionFoodItemDescription: yup.string().required(),
    file: yup.mixed().when('nutritionFoodItemImg', {
        is: (value: string) => !value,
        then: yup.mixed().required('Please provide an image')
    })
});
export const sleepValidation = yup.object({
    sleepHygieneTitle: yup.string().required(),
    sleepHygieneDescription: yup.string().required(),
    file: yup.mixed().when('sleepingHygieneImg', {
        is: (value: string) => !value,
        then: yup.mixed().required('Please provide an image')
    })
});
export const yogaValidation = yup.object({
    yogaItemTitle: yup.string().required(),
    yogaItemDescription: yup.string().required(),
    file: yup.mixed().when('yogaItemImg', {
        is: (value: string) => !value,
        then: yup.mixed().required('Please provide an image')
    })
});
