import request from '../utils/request'

const dataService = {
    async getAllRestaurants() {
        return request({
            url: '/api/restaurants',
            method: 'get'
        });
    },

    async getAllRestaurantsBySearchKey(keyWord) {
        return request({
            url: `/api/restaurants/${keyWord}`,
            method: 'get'
        });
    },
}

export default dataService;