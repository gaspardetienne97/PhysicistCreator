import React from 'react';
import PropTypes from 'prop-types';
import {withStyles} from '@material-ui/core/styles';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import Button from '@material-ui/core/Button';
import IconButton from '@material-ui/core/IconButton';
import MenuIcon from '@material-ui/icons/Menu';
import Card from '@material-ui/core/Card';
import CardActionArea from '@material-ui/core/CardActionArea';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Drawer from './Main';
import {Link} from 'react-router-dom'

const styles = {
    root: {
        flexGrow: 1,
    },
    grow: {
        flexGrow: 1,
    },
    menuButton: {
        marginLeft: -12,
        marginRight: 20,
    },
    card: {
        maxWidth: 345,
    },
    media: {
        height: 140,
    },
};


class  Gallery extends React.Component {
    render(){
        const {classes, theme} = this.props;

        return (

        <div className={classes.root}>
            <Card className={classes.card}>
                <CardActionArea>
                    <CardMedia
                        className={classes.media}
                        image="/static/images/cards/contemplative-reptile.jpg"
                        title="Contemplative Reptile"
                    />
                    <CardContent>
                        <Typography gutterBottom variant="h5" component="h2">
                            Math Module
                        </Typography>
                        <Typography component="p">
                          Our math module will go here it will be comprised of the visualization of a line integral in 3D space
                        </Typography>
                    </CardContent>
                </CardActionArea>
                <CardActions>
                    <Link to='/simulation'>
                    <Button size="small" color="primary" >
                        Learn More
                    </Button>
                    </Link>
                </CardActions>
            </Card>
            <Card className={classes.card}>
                <CardActionArea>
                    <CardMedia
                        className={classes.media}
                        image="/static/images/cards/contemplative-reptile.jpg"
                        title="Contemplative Reptile"
                    />
                    <CardContent>
                        <Typography gutterBottom variant="h5" component="h2">
                            Physics Module
                        </Typography>
                        <Typography component="p">
                          Our physics module will build upon our math module and explain flux using line integrals.
                        </Typography>
                    </CardContent>
                </CardActionArea>
                <CardActions>
                    <Link to='/simulation'>
                    <Button size="small" color="primary">
                    Learn More
                    </Button>
                    </Link>
                </CardActions>
            </Card>
        </div>
    );
}
}

Gallery.propTypes = {
    classes: PropTypes.object.isRequired,
};

export default withStyles(styles)(Gallery);