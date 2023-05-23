const express = require("express");
const router = express.Router();

// predmets
const predmetsController = require('../controllers/predmetsController');

router.get('/', predmetsController.getAll);

router.get('/createform', predmetsController.createForm);
router.post('/', predmetsController.create);

router.get('/editform/:id', predmetsController.updateForm);
router.post('/edit/:id', predmetsController.update);

router.post('/delete/:id', predmetsController.delete);

module.exports = router;
